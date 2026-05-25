using BlueAtelier.Application.Modelos;
using BlueAtelier.Application.Servicos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Infrastructure.Persistencia;
using BlueAtelier.Infrastructure.Repositorios;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Tests.Infrastructure;

public sealed class ConfiguracoesPersistenciaTests
{
    [Fact]
    public async Task Repositorio_DeveListarConfiguracoesPersistidas()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var repositorio = new ConfiguracoesRepositorio(new TestDbContextFactory(opcoes));

            var configuracoes = await repositorio.ListarConfiguracoesAsync();

            Assert.Contains(configuracoes, configuracao => configuracao.Chave == "app.idioma");
            Assert.Contains(configuracoes, configuracao => configuracao.Chave == "app.tema");
            Assert.Contains(configuracoes, configuracao => configuracao.Chave == "caminhos.raiz");
            Assert.Contains(configuracoes, configuracao => configuracao.Chave == "backup.automatico");
            Assert.All(configuracoes, configuracao => Assert.IsType<ConfiguracaoApp>(configuracao));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Repositorio_DeveObterConfiguracaoPorChave()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var repositorio = new ConfiguracoesRepositorio(new TestDbContextFactory(opcoes));

            var configuracao = await repositorio.ObterConfiguracaoAsync("app.tema");

            Assert.NotNull(configuracao);
            Assert.Equal("system", configuracao.Valor);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarConfiguracoesGerais()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarConfiguracoesServico(opcoes);

            var resumo = await servico.ObterGeraisAsync();

            Assert.IsType<ConfiguracoesGeraisResumo>(resumo);
            Assert.Equal("pt-BR", resumo.Idioma);
            Assert.Equal("system", resumo.Tema);
            Assert.Equal("comfortable", resumo.Densidade);
            Assert.Equal("blue", resumo.CorDestaque);
            Assert.Equal("C:/BlueAtelier", resumo.DiretorioRaiz);
            Assert.Equal("C:/BlueAtelier/Modelos", resumo.DiretorioModelos);
            Assert.Equal("C:/BlueAtelier/Backups", resumo.DiretorioBackups);
            Assert.False(resumo.BackupAutomatico);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Seed_DeveCriarConfiguracoesSemDuplicar()
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

            Assert.Equal(8, await consulta.ConfiguracoesApp.CountAsync());
            Assert.Equal(1, await consulta.ConfiguracoesApp.CountAsync(item => item.Chave == "app.idioma"));
            Assert.Equal(1, await consulta.ConfiguracoesApp.CountAsync(item => item.Chave == "caminhos.raiz"));
            Assert.Equal(1, await consulta.ConfiguracoesApp.CountAsync(item => item.Chave == "backup.automatico"));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveAplicarPadroesQuandoChavesNaoExistem()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
            }

            var servico = CriarConfiguracoesServico(opcoes);

            var resumo = await servico.ObterGeraisAsync();

            Assert.Equal("pt-BR", resumo.Idioma);
            Assert.Equal("system", resumo.Tema);
            Assert.Equal("comfortable", resumo.Densidade);
            Assert.Equal("blue", resumo.CorDestaque);
            Assert.Equal("C:/BlueAtelier", resumo.DiretorioRaiz);
            Assert.Equal("C:/BlueAtelier/Modelos", resumo.DiretorioModelos);
            Assert.Equal("C:/BlueAtelier/Backups", resumo.DiretorioBackups);
            Assert.False(resumo.BackupAutomatico);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_NaoExpoeEntidadeDeDominioParaUi()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarConfiguracoesServico(opcoes);

            var resumo = await servico.ObterGeraisAsync();

            Assert.IsType<ConfiguracoesGeraisResumo>(resumo);
            Assert.IsNotType<ConfiguracaoApp>((object)resumo);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_NaoValidaCaminhosReais()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.ConfiguracoesApp.Add(new ConfiguracaoApp
                {
                    Chave = "caminhos.raiz",
                    Valor = "Z:/caminho-inexistente/blueatelier",
                    AtualizadoEm = DateTimeOffset.UtcNow
                });

                await contexto.SaveChangesAsync();
            }

            var servico = CriarConfiguracoesServico(opcoes);

            var resumo = await servico.ObterGeraisAsync();

            Assert.Equal("Z:/caminho-inexistente/blueatelier", resumo.DiretorioRaiz);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    private static async Task AplicarSeedAsync(DbContextOptions<BlueAtelierDbContext> opcoes)
    {
        await using var contexto = new BlueAtelierDbContext(opcoes);
        await contexto.Database.MigrateAsync();
        await BlueAtelierSeed.AplicarAsync(contexto);
    }

    private static ConfiguracoesServico CriarConfiguracoesServico(
        DbContextOptions<BlueAtelierDbContext> opcoes)
    {
        return new ConfiguracoesServico(new ConfiguracoesRepositorio(new TestDbContextFactory(opcoes)));
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
