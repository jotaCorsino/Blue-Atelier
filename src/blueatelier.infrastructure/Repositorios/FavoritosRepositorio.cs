using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Infrastructure.Repositorios;

public sealed class FavoritosRepositorio(
    IDbContextFactory<BlueAtelierDbContext> dbContextFactory) : IFavoritosRepositorio
{
    public async Task<IReadOnlyList<LinkFavorito>> ListarLinksAsync(
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.LinksFavoritos
            .AsNoTracking()
            .OrderBy(link => link.Ordem)
            .ThenBy(link => link.Nome)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<PastaFavoritos>> ListarPastasAsync(
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.PastasFavoritos
            .AsNoTracking()
            .OrderBy(pasta => pasta.Ordem)
            .ThenBy(pasta => pasta.Nome)
            .ToListAsync(cancellationToken);
    }

    public async Task<LinkFavorito?> ObterLinkPorIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.LinksFavoritos
            .AsNoTracking()
            .SingleOrDefaultAsync(link => link.Id == id, cancellationToken);
    }

    public async Task<PastaFavoritos?> ObterPastaPorIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.PastasFavoritos
            .AsNoTracking()
            .SingleOrDefaultAsync(pasta => pasta.Id == id, cancellationToken);
    }

    public async Task<LinkFavorito> SalvarLinkAsync(
        LinkFavorito link,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.LinksFavoritos
            .SingleOrDefaultAsync(item => item.Id == link.Id, cancellationToken);

        if (existente is null)
        {
            contexto.LinksFavoritos.Add(link);
        }
        else
        {
            contexto.Entry(existente).CurrentValues.SetValues(link);
        }

        await contexto.SaveChangesAsync(cancellationToken);

        return link;
    }

    public async Task<PastaFavoritos> SalvarPastaAsync(
        PastaFavoritos pasta,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.PastasFavoritos
            .SingleOrDefaultAsync(item => item.Id == pasta.Id, cancellationToken);

        if (existente is null)
        {
            contexto.PastasFavoritos.Add(pasta);
        }
        else
        {
            contexto.Entry(existente).CurrentValues.SetValues(pasta);
        }

        await contexto.SaveChangesAsync(cancellationToken);

        return pasta;
    }

    public async Task RemoverLinkAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.LinksFavoritos
            .SingleOrDefaultAsync(link => link.Id == id, cancellationToken);

        if (existente is null)
        {
            return;
        }

        contexto.LinksFavoritos.Remove(existente);
        await contexto.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoverPastaAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.PastasFavoritos
            .SingleOrDefaultAsync(pasta => pasta.Id == id, cancellationToken);

        if (existente is null)
        {
            return;
        }

        contexto.PastasFavoritos.Remove(existente);
        await contexto.SaveChangesAsync(cancellationToken);
    }
}
