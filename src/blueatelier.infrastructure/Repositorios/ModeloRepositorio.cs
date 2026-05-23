using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Infrastructure.Repositorios;

public sealed class ModeloRepositorio(IDbContextFactory<BlueAtelierDbContext> dbContextFactory) : IModeloRepositorio
{
    public async Task<IReadOnlyList<Modelo>> ListarAsync(CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var modelos = await contexto.Modelos
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return Ordenar(modelos);
    }

    public async Task<IReadOnlyList<Modelo>> ListarPorColecaoAsync(
        Guid colecaoId,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var modelos = await contexto.Modelos
            .AsNoTracking()
            .Where(modelo => modelo.ColecaoId == colecaoId)
            .ToListAsync(cancellationToken);

        return Ordenar(modelos);
    }

    public async Task<Modelo?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.Modelos
            .AsNoTracking()
            .SingleOrDefaultAsync(modelo => modelo.Id == id, cancellationToken);
    }

    public async Task<Modelo> SalvarAsync(Modelo entidade, CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.Modelos
            .SingleOrDefaultAsync(modelo => modelo.Id == entidade.Id, cancellationToken);

        if (existente is null)
        {
            contexto.Modelos.Add(entidade);
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

        var existente = await contexto.Modelos
            .SingleOrDefaultAsync(modelo => modelo.Id == id, cancellationToken);

        if (existente is null)
        {
            return;
        }

        contexto.Modelos.Remove(existente);
        await contexto.SaveChangesAsync(cancellationToken);
    }

    private static List<Modelo> Ordenar(IEnumerable<Modelo> modelos)
    {
        return modelos
            .OrderByDescending(modelo => modelo.AtualizadoEm)
            .ThenBy(modelo => modelo.Nome)
            .ToList();
    }
}
