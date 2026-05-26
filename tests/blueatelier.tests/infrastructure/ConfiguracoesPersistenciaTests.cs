using BlueAtelier.Application.Modelos;
using BlueAtelier.Application.Servicos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;
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

    [Fact]
    public async Task Repositorio_DeveListarCaminhosPersistidos()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var repositorio = new ConfiguracoesRepositorio(new TestDbContextFactory(opcoes));

            var caminhos = await repositorio.ListarCaminhosAsync();

            Assert.Contains(caminhos, caminho => caminho.Nome == "Raiz do atelier");
            Assert.Contains(caminhos, caminho => caminho.Nome == "Modelos");
            Assert.Contains(caminhos, caminho => caminho.Nome == "Backups");
            Assert.Contains(caminhos, caminho => caminho.Nome == "Exporta\u00e7\u00f5es");
            Assert.All(caminhos, caminho => Assert.IsType<CaminhoConfigurado>(caminho));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarResumoDeCaminhos()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarConfiguracoesServico(opcoes);

            var caminhos = await servico.ListarCaminhosAsync();

            Assert.Contains(caminhos, caminho =>
                caminho.Nome == "Raiz do atelier"
                && caminho.Tipo == "raiz"
                && caminho.Caminho == "C:/BlueAtelier"
                && caminho.StatusVisual == "Conectado"
                && caminho.EhObrigatorio);
            Assert.All(caminhos, caminho => Assert.IsType<ConfiguracaoCaminhoResumo>(caminho));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Seed_DeveCriarCaminhosSemDuplicar()
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

            Assert.Equal(4, await consulta.CaminhosConfigurados.CountAsync());
            Assert.Equal(1, await consulta.CaminhosConfigurados.CountAsync(item => item.Tipo == TipoCaminhoConfigurado.PrincipalAtelier));
            Assert.Equal(1, await consulta.CaminhosConfigurados.CountAsync(item => item.Tipo == TipoCaminhoConfigurado.Modelos));
            Assert.Equal(1, await consulta.CaminhosConfigurados.CountAsync(item => item.Tipo == TipoCaminhoConfigurado.Backup));
            Assert.Equal(1, await consulta.CaminhosConfigurados.CountAsync(item => item.Tipo == TipoCaminhoConfigurado.Exportacao));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarListaVaziaQuandoNaoHouverCaminhos()
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

            var caminhos = await servico.ListarCaminhosAsync();

            Assert.Empty(caminhos);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeCaminhos_NaoExpoeEntidadeDeDominioParaUi()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarConfiguracoesServico(opcoes);

            var caminhos = await servico.ListarCaminhosAsync();
            var primeiroCaminho = Assert.Single(caminhos, caminho => caminho.Tipo == "raiz");

            Assert.IsType<ConfiguracaoCaminhoResumo>(primeiroCaminho);
            Assert.IsNotType<CaminhoConfigurado>((object)primeiroCaminho);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeCaminhos_NaoValidaCaminhosReais()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.CaminhosConfigurados.Add(new CaminhoConfigurado
                {
                    Nome = "Caminho inexistente",
                    Caminho = "Z:/caminho-inexistente/blueatelier",
                    Tipo = TipoCaminhoConfigurado.Rede,
                    EstaAtivo = true,
                    AtualizadoEm = DateTimeOffset.UtcNow
                });

                await contexto.SaveChangesAsync();
            }

            var servico = CriarConfiguracoesServico(opcoes);

            var caminhos = await servico.ListarCaminhosAsync();

            Assert.Contains(caminhos, caminho =>
                caminho.Nome == "Caminho inexistente"
                && caminho.Caminho == "Z:/caminho-inexistente/blueatelier"
                && caminho.StatusVisual == "Conectado");
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
