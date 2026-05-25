using BlueAtelier.Application.Modelos;
using BlueAtelier.Application.Servicos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;
using BlueAtelier.Infrastructure.Persistencia;
using BlueAtelier.Infrastructure.Repositorios;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Tests.Infrastructure;

public sealed class BuscaPersistenciaTests
{
    [Fact]
    public async Task Servico_DeveRetornarResultadosParaTermoDeColecao()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarBuscaServico(opcoes);

            var resultados = await servico.BuscarAsync("Eldritch");

            Assert.Contains(resultados, resultado =>
                resultado.Tipo == "Colecao"
                && resultado.Titulo == "Eldritch Horrors"
                && resultado.Rota == "/colecoes/eldritch-horrors");
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarResultadosParaTermoDeModelo()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarBuscaServico(opcoes);

            var resultados = await servico.BuscarAsync("Cthulhu");

            Assert.Contains(resultados, resultado =>
                resultado.Tipo == "Modelo"
                && resultado.Titulo == "Cthulhu Idol"
                && resultado.Rota == "/colecoes/eldritch-horrors/modelos/cthulhu-idol");
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarArquivosVinculadosComoMetadados()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarBuscaServico(opcoes);

            var resultados = await servico.BuscarAsync("stl");

            Assert.Contains(resultados, resultado =>
                resultado.Tipo == "Arquivo"
                && resultado.Titulo == "cthulhu-idol.stl"
                && resultado.Rota == "/colecoes/eldritch-horrors/modelos/cthulhu-idol/arquivos");
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarImagensComoMetadados()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarBuscaServico(opcoes);

            var resultados = await servico.BuscarAsync("Main reference");

            Assert.Contains(resultados, resultado =>
                resultado.Tipo == "Imagem"
                && resultado.Titulo == "Main reference"
                && resultado.Rota == "/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria/main-reference");
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarFavoritos()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarBuscaServico(opcoes);

            var resultados = await servico.BuscarAsync("ArtStation");

            var favorito = Assert.Single(resultados, resultado => resultado.Titulo == "ArtStation");
            Assert.IsType<BuscaResultado>(favorito);
            Assert.Equal("Favorito", favorito.Tipo);
            Assert.Equal("/favoritos", favorito.Rota);
            Assert.Equal("https://www.artstation.com", favorito.Descricao);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarListaInicialQuandoTermoEstaVazio()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarBuscaServico(opcoes);

            var resultados = await servico.BuscarAsync(string.Empty);

            Assert.NotEmpty(resultados);
            Assert.Contains(resultados, resultado => resultado.Tipo == "Colecao");
            Assert.Contains(resultados, resultado => resultado.Tipo == "Modelo");
            Assert.All(resultados, resultado => Assert.IsType<BuscaResultado>(resultado));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_NaoExpoeEntidadesDeDominioParaUi()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarBuscaServico(opcoes);

            var resultados = await servico.BuscarAsync("Cthulhu");

            Assert.All(resultados, resultado => Assert.IsType<BuscaResultado>(resultado));
            Assert.All(resultados, resultado => Assert.IsNotType<Colecao>((object)resultado));
            Assert.All(resultados, resultado => Assert.IsNotType<Modelo>((object)resultado));
            Assert.All(resultados, resultado => Assert.IsNotType<ArquivoVinculado>((object)resultado));
            Assert.All(resultados, resultado => Assert.IsNotType<ImagemDoModelo>((object)resultado));
            Assert.All(resultados, resultado => Assert.IsNotType<LinkFavorito>((object)resultado));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_NaoDependeDeRedeOuSistemaDeArquivos()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                var modelo = await contexto.Modelos.SingleAsync(item => item.Slug == "cthulhu-idol");
                contexto.ArquivosVinculados.Add(new ArquivoVinculado
                {
                    ModeloId = modelo.Id,
                    Nome = "arquivo-inexistente.stl",
                    CaminhoLocal = "Z:/blue-atelier/caminho-inexistente/arquivo-inexistente.stl",
                    Tipo = TipoArquivoVinculado.Modelo3D,
                    Extensao = ".stl",
                    TamanhoBytes = 512
                });

                await contexto.SaveChangesAsync();
            }

            var servico = CriarBuscaServico(opcoes);

            var resultados = await servico.BuscarAsync("caminho-inexistente");

            Assert.Contains(resultados, resultado =>
                resultado.Tipo == "Arquivo"
                && resultado.Titulo == "arquivo-inexistente.stl");
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

    private static BuscaServico CriarBuscaServico(DbContextOptions<BlueAtelierDbContext> opcoes)
    {
        var factory = new TestDbContextFactory(opcoes);

        return new BuscaServico(
            new ColecaoRepositorio(factory),
            new ModeloRepositorio(factory),
            new ArquivoVinculadoRepositorio(factory),
            new ImagemModeloRepositorio(factory),
            new FavoritosRepositorio(factory));
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
