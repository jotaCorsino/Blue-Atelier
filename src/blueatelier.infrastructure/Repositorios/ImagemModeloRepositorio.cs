using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Infrastructure.Repositorios;

public sealed class ImagemModeloRepositorio(
    IDbContextFactory<BlueAtelierDbContext> dbContextFactory) : IImagemModeloRepositorio
{
    public async Task<IReadOnlyList<ImagemDoModelo>> ListarAsync(
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var imagens = await contexto.ImagensDoModelo
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return Ordenar(imagens);
    }

    public async Task<IReadOnlyList<ImagemDoModelo>> ListarPorModeloAsync(
        Guid modeloId,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var imagens = await contexto.ImagensDoModelo
            .AsNoTracking()
            .Where(imagem => imagem.ModeloId == modeloId)
            .ToListAsync(cancellationToken);

        return Ordenar(imagens);
    }

    public async Task<ImagemDoModelo?> ObterPorIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.ImagensDoModelo
            .AsNoTracking()
            .SingleOrDefaultAsync(imagem => imagem.Id == id, cancellationToken);
    }

    public async Task<ImagemDoModelo> SalvarAsync(
        ImagemDoModelo entidade,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.ImagensDoModelo
            .SingleOrDefaultAsync(imagem => imagem.Id == entidade.Id, cancellationToken);

        if (existente is null)
        {
            contexto.ImagensDoModelo.Add(entidade);
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

        var existente = await contexto.ImagensDoModelo
            .SingleOrDefaultAsync(imagem => imagem.Id == id, cancellationToken);

        if (existente is null)
        {
            return;
        }

        contexto.ImagensDoModelo.Remove(existente);
        await contexto.SaveChangesAsync(cancellationToken);
    }

    private static List<ImagemDoModelo> Ordenar(IEnumerable<ImagemDoModelo> imagens)
    {
        return imagens
            .OrderByDescending(imagem => imagem.EhPrincipal)
            .ThenBy(imagem => imagem.Ordem)
            .ThenBy(imagem => imagem.Titulo)
            .ToList();
    }
}
