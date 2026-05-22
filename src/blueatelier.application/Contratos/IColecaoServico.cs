using BlueAtelier.Application.Modelos;

namespace BlueAtelier.Application.Contratos;

public interface IColecaoServico
{
    Task<IReadOnlyList<ColecaoResumo>> ListarResumoAsync(CancellationToken cancellationToken = default);

    Task<ColecaoDetalhe?> ObterDetalhePorSlugAsync(string slug, CancellationToken cancellationToken = default);
}
