using BlueAtelier.Application.Modelos;

namespace BlueAtelier.Application.Contratos;

public interface IColecaoServico
{
    Task<IReadOnlyList<ColecaoResumo>> ListarResumoAsync(CancellationToken cancellationToken = default);
}
