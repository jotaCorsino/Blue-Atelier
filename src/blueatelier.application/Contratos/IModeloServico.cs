using BlueAtelier.Application.Modelos;

namespace BlueAtelier.Application.Contratos;

public interface IModeloServico
{
    Task<IReadOnlyList<ModeloResumo>> ListarResumoAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ModeloResumoColecao>> ListarPorColecaoAsync(
        Guid colecaoId,
        CancellationToken cancellationToken = default);

    Task<ModeloDetalhe?> ObterDetalhePorSlugAsync(
        string colecaoSlug,
        string modeloSlug,
        CancellationToken cancellationToken = default);
}
