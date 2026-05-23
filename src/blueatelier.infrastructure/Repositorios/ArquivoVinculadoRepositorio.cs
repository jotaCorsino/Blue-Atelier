using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Infrastructure.Repositorios;

public sealed class ArquivoVinculadoRepositorio(
    IDbContextFactory<BlueAtelierDbContext> dbContextFactory) : IArquivoVinculadoRepositorio
{
    public async Task<IReadOnlyList<ArquivoVinculado>> ListarAsync(
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var arquivos = await contexto.ArquivosVinculados
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return Ordenar(arquivos);
    }

    public async Task<IReadOnlyList<ArquivoVinculado>> ListarPorModeloAsync(
        Guid modeloId,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var arquivos = await contexto.ArquivosVinculados
            .AsNoTracking()
            .Where(arquivo => arquivo.ModeloId == modeloId)
            .ToListAsync(cancellationToken);

        return Ordenar(arquivos);
    }

    public async Task<ArquivoVinculado?> ObterPorIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.ArquivosVinculados
            .AsNoTracking()
            .SingleOrDefaultAsync(arquivo => arquivo.Id == id, cancellationToken);
    }

    public async Task<ArquivoVinculado> SalvarAsync(
        ArquivoVinculado entidade,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.ArquivosVinculados
            .SingleOrDefaultAsync(arquivo => arquivo.Id == entidade.Id, cancellationToken);

        if (existente is null)
        {
            contexto.ArquivosVinculados.Add(entidade);
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

        var existente = await contexto.ArquivosVinculados
            .SingleOrDefaultAsync(arquivo => arquivo.Id == id, cancellationToken);

        if (existente is null)
        {
            return;
        }

        contexto.ArquivosVinculados.Remove(existente);
        await contexto.SaveChangesAsync(cancellationToken);
    }

    private static List<ArquivoVinculado> Ordenar(IEnumerable<ArquivoVinculado> arquivos)
    {
        return arquivos
            .OrderBy(arquivo => arquivo.Tipo)
            .ThenBy(arquivo => arquivo.Nome)
            .ToList();
    }
}
