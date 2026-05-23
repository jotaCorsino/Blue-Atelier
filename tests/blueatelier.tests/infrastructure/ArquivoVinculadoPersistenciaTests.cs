using BlueAtelier.Application.Modelos;
using BlueAtelier.Application.Servicos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;
using BlueAtelier.Infrastructure.Persistencia;
using BlueAtelier.Infrastructure.Repositorios;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Tests.Infrastructure;

public sealed class ArquivoVinculadoPersistenciaTests
{
    [Fact]
    public async Task Repositorio_DeveListarArquivosDoModeloCorreto()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var modeloId = Guid.NewGuid();
            var outroModeloId = Guid.NewGuid();

            await CriarModeloComArquivosAsync(opcoes, modeloId, outroModeloId);

            var repositorio = new ArquivoVinculadoRepositorio(new TestDbContextFactory(opcoes));

            var arquivos = await repositorio.ListarPorModeloAsync(modeloId);

            Assert.Equal(2, arquivos.Count);
            Assert.All(arquivos, arquivo => Assert.Equal(modeloId, arquivo.ModeloId));
            Assert.Contains(arquivos, arquivo => arquivo.Nome == "cthulhu-idol.stl");
            Assert.Contains(arquivos, arquivo => arquivo.Nome == "painting-notes.md");
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Repositorio_NaoDeveMisturarArquivosDeOutroModelo()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var modeloId = Guid.NewGuid();
            var outroModeloId = Guid.NewGuid();

            await CriarModeloComArquivosAsync(opcoes, modeloId, outroModeloId);

            var repositorio = new ArquivoVinculadoRepositorio(new TestDbContextFactory(opcoes));

            var arquivos = await repositorio.ListarPorModeloAsync(modeloId);

            Assert.DoesNotContain(arquivos, arquivo => arquivo.Nome == "ruined-arch.stl");
            Assert.DoesNotContain(arquivos, arquivo => arquivo.ModeloId == outroModeloId);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarResumoDeArquivosVinculados()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var modeloId = Guid.NewGuid();
            var outroModeloId = Guid.NewGuid();

            await CriarModeloComArquivosAsync(opcoes, modeloId, outroModeloId);

            var repositorio = new ArquivoVinculadoRepositorio(new TestDbContextFactory(opcoes));
            var servico = new ArquivoVinculadoServico(repositorio);

            var resumos = await servico.ListarPorModeloAsync(modeloId);

            var resumo = Assert.Single(resumos, arquivo => arquivo.Nome == "cthulhu-idol.stl");
            Assert.IsType<ArquivoVinculadoResumo>(resumo);
            Assert.IsNotType<ArquivoVinculado>(resumo);
            Assert.Equal(modeloId, resumo.ModeloId);
            Assert.Equal(".stl", resumo.Extensao);
            Assert.Equal(TipoArquivoVinculado.Modelo3D, resumo.Tipo);
            Assert.Equal(18_245_632, resumo.TamanhoBytes);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Seed_DeveCriarArquivosVinculadosDoCthulhuIdolSemDuplicar()
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
            var modelo = await consulta.Modelos.SingleAsync(item => item.Slug == "cthulhu-idol");
            var arquivos = await consulta.ArquivosVinculados
                .Where(arquivo => arquivo.ModeloId == modelo.Id)
                .Select(arquivo => arquivo.Nome)
                .ToListAsync();

            Assert.Equal(4, arquivos.Count);
            Assert.Contains("cthulhu-idol.stl", arquivos);
            Assert.Contains("cthulhu-idol-supported.lys", arquivos);
            Assert.Contains("cthulhu-idol-ready.ctb", arquivos);
            Assert.Contains("painting-notes.md", arquivos);
            Assert.Equal(1, arquivos.Count(nome => nome == "cthulhu-idol.stl"));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    private static async Task CriarModeloComArquivosAsync(
        DbContextOptions<BlueAtelierDbContext> opcoes,
        Guid modeloId,
        Guid outroModeloId)
    {
        var colecaoId = Guid.NewGuid();

        await using var contexto = new BlueAtelierDbContext(opcoes);
        await contexto.Database.MigrateAsync();
        contexto.Colecoes.Add(new Colecao
        {
            Id = colecaoId,
            Nome = "Eldritch Horrors",
            Slug = "eldritch-horrors"
        });
        contexto.Modelos.AddRange(
            new Modelo
            {
                Id = modeloId,
                ColecaoId = colecaoId,
                Nome = "Cthulhu Idol",
                Slug = "cthulhu-idol",
                EtapaAtual = EtapaModelo.Pintura,
                ProgressoPercentual = 60
            },
            new Modelo
            {
                Id = outroModeloId,
                ColecaoId = colecaoId,
                Nome = "Ruined Arch",
                Slug = "ruined-arch",
                EtapaAtual = EtapaModelo.Modelagem,
                ProgressoPercentual = 20
            });
        contexto.ArquivosVinculados.AddRange(
            new ArquivoVinculado
            {
                ModeloId = modeloId,
                Nome = "cthulhu-idol.stl",
                CaminhoLocal = "C:/BlueAtelier/EldritchHorrors/CthulhuIdol/cthulhu-idol.stl",
                Tipo = TipoArquivoVinculado.Modelo3D,
                Extensao = ".stl",
                TamanhoBytes = 18_245_632
            },
            new ArquivoVinculado
            {
                ModeloId = modeloId,
                Nome = "painting-notes.md",
                CaminhoLocal = "C:/BlueAtelier/EldritchHorrors/CthulhuIdol/painting-notes.md",
                Tipo = TipoArquivoVinculado.Nota,
                Extensao = ".md",
                TamanhoBytes = 12_288
            },
            new ArquivoVinculado
            {
                ModeloId = outroModeloId,
                Nome = "ruined-arch.stl",
                CaminhoLocal = "C:/BlueAtelier/AncientRuins/RuinedArch/ruined-arch.stl",
                Tipo = TipoArquivoVinculado.Modelo3D,
                Extensao = ".stl",
                TamanhoBytes = 8_192
            });

        await contexto.SaveChangesAsync();
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
