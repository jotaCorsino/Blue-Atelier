using BlueAtelier.Application.Servicos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;
using BlueAtelier.Infrastructure.Persistencia;
using BlueAtelier.Infrastructure.Repositorios;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Tests.Infrastructure;

public sealed class ModeloPersistenciaTests
{
    [Fact]
    public async Task Repositorio_DeveListarModelosDaColecao()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var colecaoId = Guid.NewGuid();
            var outraColecaoId = Guid.NewGuid();

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.Colecoes.AddRange(
                    new Colecao
                    {
                        Id = colecaoId,
                        Nome = "Eldritch Horrors",
                        Slug = "eldritch-horrors"
                    },
                    new Colecao
                    {
                        Id = outraColecaoId,
                        Nome = "Ancient Ruins",
                        Slug = "ancient-ruins"
                    });

                contexto.Modelos.AddRange(
                    new Modelo
                    {
                        ColecaoId = colecaoId,
                        Nome = "Cthulhu Idol",
                        Slug = "cthulhu-idol",
                        EtapaAtual = EtapaModelo.Pintura,
                        ProgressoPercentual = 60,
                        AtualizadoEm = DateTimeOffset.UtcNow
                    },
                    new Modelo
                    {
                        ColecaoId = colecaoId,
                        Nome = "Deep One Bust",
                        Slug = "deep-one-bust",
                        EtapaAtual = EtapaModelo.Impressao,
                        ProgressoPercentual = 25,
                        AtualizadoEm = DateTimeOffset.UtcNow.AddDays(-1)
                    },
                    new Modelo
                    {
                        ColecaoId = outraColecaoId,
                        Nome = "Ruined Arch",
                        Slug = "ruined-arch",
                        EtapaAtual = EtapaModelo.Modelagem,
                        ProgressoPercentual = 40,
                        AtualizadoEm = DateTimeOffset.UtcNow.AddDays(-2)
                    });

                await contexto.SaveChangesAsync();
            }

            var repositorio = new ModeloRepositorio(new TestDbContextFactory(opcoes));

            var modelos = await repositorio.ListarPorColecaoAsync(colecaoId);

            Assert.Equal(2, modelos.Count);
            Assert.All(modelos, modelo => Assert.Equal(colecaoId, modelo.ColecaoId));
            Assert.DoesNotContain(modelos, modelo => modelo.Slug == "ruined-arch");
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarResumoDeModelosDaColecao()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var colecaoId = Guid.NewGuid();

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.Colecoes.Add(new Colecao
                {
                    Id = colecaoId,
                    Nome = "Eldritch Horrors",
                    Slug = "eldritch-horrors"
                });
                contexto.Modelos.Add(new Modelo
                {
                    ColecaoId = colecaoId,
                    Nome = "Cthulhu Idol",
                    Slug = "cthulhu-idol",
                    Descricao = "Idolo principal da colecao",
                    EtapaAtual = EtapaModelo.Pintura,
                    ProgressoPercentual = 60,
                    TipoArquivo = "STL",
                    Escala = "32mm",
                    TempoEstimado = "6h",
                    MaterialSugerido = "Resin Grey"
                });

                await contexto.SaveChangesAsync();
            }

            var repositorio = new ModeloRepositorio(new TestDbContextFactory(opcoes));
            var servico = new ModeloServico(repositorio);

            var resumos = await servico.ListarPorColecaoAsync(colecaoId);

            var resumo = Assert.Single(resumos);
            Assert.Equal("Cthulhu Idol", resumo.Nome);
            Assert.Equal("cthulhu-idol", resumo.Slug);
            Assert.Equal(EtapaModelo.Pintura, resumo.EtapaAtual);
            Assert.Equal(60, resumo.ProgressoPercentual);
            Assert.Equal("Resin Grey", resumo.MaterialSugerido);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Seed_DeveCriarModelosDeEldritchHorrorsSemDuplicar()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                await BlueAtelierSeed.AplicarAsync(contexto);
                await BlueAtelierSeed.AplicarAsync(contexto);
            }

            await using var consulta = new BlueAtelierDbContext(opcoes);
            var colecao = await consulta.Colecoes.SingleAsync(item => item.Slug == "eldritch-horrors");
            var modelos = await consulta.Modelos
                .Where(modelo => modelo.ColecaoId == colecao.Id)
                .Select(modelo => modelo.Slug)
                .ToListAsync();

            Assert.Equal(6, modelos.Count);
            Assert.Contains("cthulhu-idol", modelos);
            Assert.Contains("deep-one-bust", modelos);
            Assert.Contains("tentacle-beast", modelos);
            Assert.Contains("ancient-cultist", modelos);
            Assert.Contains("forgotten-horror", modelos);
            Assert.Contains("abyssal-statue", modelos);
            Assert.Equal(1, modelos.Count(slug => slug == "cthulhu-idol"));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    private static string CriarCaminhoBancoTemporario()
    {
        return Path.Combine(Path.GetTempPath(), $"blueatelier-{Guid.NewGuid():N}.db");
    }

    private static void RemoverBancoTemporario(string caminhoBanco)
    {
        SqliteConnection.ClearAllPools();
        GC.Collect();
        GC.WaitForPendingFinalizers();

        foreach (var caminho in new[] { caminhoBanco, $"{caminhoBanco}-wal", $"{caminhoBanco}-shm" })
        {
            if (File.Exists(caminho))
            {
                File.Delete(caminho);
            }
        }
    }

    private sealed class TestDbContextFactory(DbContextOptions<BlueAtelierDbContext> opcoes) : IDbContextFactory<BlueAtelierDbContext>
    {
        public BlueAtelierDbContext CreateDbContext()
        {
            return new BlueAtelierDbContext(opcoes);
        }
    }
}
