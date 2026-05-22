using BlueAtelier.Application.Servicos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Infrastructure.Persistencia;
using BlueAtelier.Infrastructure.Repositorios;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Tests.Infrastructure;

public sealed class ColecaoPersistenciaTests
{
    [Fact]
    public async Task Repositorio_DeveListarColecoesEObterPorSlug()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();

                contexto.Colecoes.AddRange(
                    new Colecao
                    {
                        Nome = "Eldritch Horrors",
                        Slug = "eldritch-horrors",
                        AtualizadoEm = DateTimeOffset.UtcNow
                    },
                    new Colecao
                    {
                        Nome = "Ancient Ruins",
                        Slug = "ancient-ruins",
                        AtualizadoEm = DateTimeOffset.UtcNow.AddDays(-1)
                    });

                await contexto.SaveChangesAsync();
            }

            var repositorio = new ColecaoRepositorio(new TestDbContextFactory(opcoes));

            var colecoes = await repositorio.ListarAsync();
            var colecao = await repositorio.ObterPorSlugAsync("eldritch-horrors");

            Assert.Equal(2, colecoes.Count);
            Assert.Equal("Eldritch Horrors", colecoes[0].Nome);
            Assert.NotNull(colecao);
            Assert.Equal("eldritch-horrors", colecao.Slug);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarResumoDeColecoes()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.Colecoes.Add(new Colecao
                {
                    Nome = "Eldritch Horrors",
                    Slug = "eldritch-horrors",
                    Descricao = "Colecao de teste",
                    ImagemCapa = "cover-eldritch"
                });

                await contexto.SaveChangesAsync();
            }

            var repositorio = new ColecaoRepositorio(new TestDbContextFactory(opcoes));
            var servico = new ColecaoServico(repositorio);

            var resumos = await servico.ListarResumoAsync();

            var resumo = Assert.Single(resumos);
            Assert.Equal("Eldritch Horrors", resumo.Nome);
            Assert.Equal("eldritch-horrors", resumo.Slug);
            Assert.Equal("cover-eldritch", resumo.ImagemCapa);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Inicializador_DeveAplicarMigrationESeedSemDuplicarColecoes()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var inicializador = new BlueAtelierBancoInicializador(new TestDbContextFactory(opcoes));

            await inicializador.InicializarAsync();
            await inicializador.InicializarAsync();

            await using var contexto = new BlueAtelierDbContext(opcoes);

            Assert.Equal(8, await contexto.Colecoes.CountAsync());
            Assert.Equal(1, await contexto.Colecoes.CountAsync(colecao => colecao.Slug == "eldritch-horrors"));
            Assert.Equal(1, await contexto.Modelos.CountAsync(modelo => modelo.Slug == "cthulhu-idol"));
            Assert.Equal(1, await contexto.ConfiguracoesApp.CountAsync(configuracao => configuracao.Chave == "app.idioma"));
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
