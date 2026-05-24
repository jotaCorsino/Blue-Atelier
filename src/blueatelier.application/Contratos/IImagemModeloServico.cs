using BlueAtelier.Application.Modelos;

namespace BlueAtelier.Application.Contratos;

public interface IImagemModeloServico
{
    Task<IReadOnlyList<ImagemModeloResumo>> ListarPorModeloAsync(
        Guid modeloId,
        CancellationToken cancellationToken = default);

    Task<ImagemModeloDetalhe?> ObterDetalheAsync(
        string colecaoSlug,
        string modeloSlug,
        string imagemSlug,
        CancellationToken cancellationToken = default);
}
