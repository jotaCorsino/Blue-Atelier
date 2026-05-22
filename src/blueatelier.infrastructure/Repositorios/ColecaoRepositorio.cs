using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Infrastructure.Repositorios;

public sealed class ColecaoRepositorio(IDbContextFactory<BlueAtelierDbContext> dbContextFactory) : IColecaoRepositorio
{
    public async Task<IReadOnlyList<Colecao>> ListarAsync(CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var colecoes = await contexto.Colecoes
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return colecoes
            .OrderByDescending(colecao => colecao.AtualizadoEm)
            .ThenBy(colecao => colecao.Nome)
            .ToList();
    }

    public async Task<Colecao?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.Colecoes
            .AsNoTracking()
            .SingleOrDefaultAsync(colecao => colecao.Id == id, cancellationToken);
    }

    public async Task<Colecao?> ObterPorSlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.Colecoes
            .AsNoTracking()
            .SingleOrDefaultAsync(colecao => colecao.Slug == slug, cancellationToken);
    }

    public async Task<Colecao> SalvarAsync(Colecao entidade, CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.Colecoes
            .SingleOrDefaultAsync(colecao => colecao.Id == entidade.Id, cancellationToken);

        if (existente is null)
        {
            contexto.Colecoes.Add(entidade);
        }
        else
        {
            contexto.Entry(existente).CurrentValues.SetValues(entidade);
        }

        await contexto.SaveChangesAsync(cancellationToken);

        return entidade;
    }

    public async Task RemoverAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.Colecoes
            .SingleOrDefaultAsync(colecao => colecao.Id == id, cancellationToken);

        if (existente is null)
        {
            return;
        }

        contexto.Colecoes.Remove(existente);
        await contexto.SaveChangesAsync(cancellationToken);
    }
}
