using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;
using BlueAtelier.Infrastructure.Persistencia;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Tests.Infrastructure;

public sealed class BlueAtelierDbContextTests
{
    [Fact]
    public async Task BancoSqlite_DeveSalvarEConsultarEntidadesBasicas()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            await using (var contexto = BlueAtelierDbContextFactory.CriarComSqlite(caminhoBanco))
            {
                await contexto.Database.MigrateAsync();

                var colecao = new Colecao
                {
                    Nome = "Colecao Teste",
                    Slug = "colecao-teste"
                };

                var modelo = new Modelo
                {
                    ColecaoId = colecao.Id,
                    Nome = "Modelo Teste",
                    Slug = "modelo-teste",
                    EtapaAtual = EtapaModelo.Modelagem,
                    ProgressoPercentual = 45
                };

                var link = new LinkFavorito
                {
                    Nome = "ArtStation",
                    Url = "https://www.artstation.com",
                    Iniciais = "AS",
                    Ordem = 1
                };

                var configuracao = new ConfiguracaoApp
                {
                    Chave = "app.idioma",
                    Valor = "pt-BR"
                };

                contexto.Colecoes.Add(colecao);
                contexto.Modelos.Add(modelo);
                contexto.LinksFavoritos.Add(link);
                contexto.ConfiguracoesApp.Add(configuracao);

                await contexto.SaveChangesAsync();
            }

            await using (var contexto = BlueAtelierDbContextFactory.CriarComSqlite(caminhoBanco))
            {
                var modeloSalvo = await contexto.Modelos
                    .SingleAsync(modelo => modelo.Slug == "modelo-teste");

                var linkSalvo = await contexto.LinksFavoritos
                    .SingleAsync(link => link.Url == "https://www.artstation.com");

                var configuracaoSalva = await contexto.ConfiguracoesApp
                    .SingleAsync(configuracao => configuracao.Chave == "app.idioma");

                Assert.Equal("colecao-teste", await contexto.Colecoes.Select(colecao => colecao.Slug).SingleAsync());
                Assert.Equal(EtapaModelo.Modelagem, modeloSalvo.EtapaAtual);
                Assert.Equal("ArtStation", linkSalvo.Nome);
                Assert.Equal("pt-BR", configuracaoSalva.Valor);
            }
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Seed_DeveSerSeguroParaExecutarMaisDeUmaVez()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            await using (var contexto = BlueAtelierDbContextFactory.CriarComSqlite(caminhoBanco))
            {
                await contexto.Database.MigrateAsync();
                await BlueAtelierSeed.AplicarAsync(contexto);
                await BlueAtelierSeed.AplicarAsync(contexto);
            }

            await using (var contexto = BlueAtelierDbContextFactory.CriarComSqlite(caminhoBanco))
            {
                Assert.Equal(8, await contexto.Colecoes.CountAsync());
                Assert.Equal(1, await contexto.Colecoes.CountAsync(colecao => colecao.Slug == "eldritch-horrors"));
                Assert.Equal(1, await contexto.Modelos.CountAsync(modelo => modelo.Slug == "cthulhu-idol"));
                Assert.Equal(1, await contexto.ConfiguracoesApp.CountAsync(configuracao => configuracao.Chave == "app.idioma"));
                Assert.Equal(4, await contexto.PastasFavoritos.CountAsync());
                Assert.Equal(10, await contexto.LinksFavoritos.CountAsync());
            }
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
}
