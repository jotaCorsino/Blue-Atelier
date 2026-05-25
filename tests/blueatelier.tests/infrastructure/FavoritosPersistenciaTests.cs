using BlueAtelier.Application.Modelos;
using BlueAtelier.Application.Servicos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Infrastructure.Persistencia;
using BlueAtelier.Infrastructure.Repositorios;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Tests.Infrastructure;

public sealed class FavoritosPersistenciaTests
{
    [Fact]
    public async Task Repositorio_DeveListarPastasPersistidas()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var repositorio = new FavoritosRepositorio(new TestDbContextFactory(opcoes));

            var pastas = await repositorio.ListarPastasAsync();

            Assert.Equal(4, pastas.Count);
            Assert.Equal("Pintura", pastas[0].Nome);
            Assert.Contains(pastas, pasta => pasta.Nome == "Referencias");
            Assert.All(pastas, pasta => Assert.IsType<PastaFavoritos>(pasta));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Repositorio_DeveListarLinksPersistidos()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var repositorio = new FavoritosRepositorio(new TestDbContextFactory(opcoes));

            var links = await repositorio.ListarLinksAsync();

            Assert.Equal(10, links.Count);
            Assert.Contains(links, link => link.Nome == "ArtStation" && link.Iniciais == "AS");
            Assert.Contains(links, link => link.Nome == "Thingiverse" && link.Iniciais == "TH");
            Assert.Contains(links, link => link.Nome == "Pinterest" && link.Iniciais == "PI");
            Assert.All(links, link => Assert.IsType<LinkFavorito>(link));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarItensDaBarraDeFavoritos()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarFavoritosServico(opcoes);

            var itens = await servico.ListarBarraAsync();

            Assert.Equal(14, itens.Count);
            Assert.Contains(itens, item => item.EhPasta && item.Nome == "Referencias");
            Assert.Contains(itens, item => !item.EhPasta && item.Nome == "ArtStation");
            Assert.All(itens, item => Assert.IsType<FavoritoBarraItem>(item));
            Assert.All(itens, item => Assert.IsNotType<LinkFavorito>((object)item));
            Assert.All(itens, item => Assert.IsNotType<PastaFavoritos>((object)item));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Seed_DeveCriarFavoritosSemDuplicar()
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

            Assert.Equal(4, await consulta.PastasFavoritos.CountAsync());
            Assert.Equal(10, await consulta.LinksFavoritos.CountAsync());
            Assert.Equal(1, await consulta.PastasFavoritos.CountAsync(pasta => pasta.Nome == "Referencias"));
            Assert.Equal(1, await consulta.LinksFavoritos.CountAsync(link => link.Url == "https://www.artstation.com"));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_NaoDependeDeFaviconRealOuRede()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            await AplicarSeedAsync(opcoes);

            var servico = CriarFavoritosServico(opcoes);

            var itens = await servico.ListarBarraAsync();
            var artStation = Assert.Single(itens, item => item.Nome == "ArtStation");

            Assert.Equal("AS", artStation.FaviconLocalOuTexto);
            Assert.Equal("https://www.artstation.com", artStation.Url);
            Assert.False(artStation.FaviconLocalOuTexto.StartsWith("http", StringComparison.OrdinalIgnoreCase));
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

    private static FavoritosServico CriarFavoritosServico(DbContextOptions<BlueAtelierDbContext> opcoes)
    {
        return new FavoritosServico(new FavoritosRepositorio(new TestDbContextFactory(opcoes)));
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
