using BlueAtelier.Application.Modelos;

namespace BlueAtelier.Application.Contratos;

public interface IBuscaServico
{
    Task<IReadOnlyList<BuscaResultado>> BuscarAsync(
        string termo,
        CancellationToken cancellationToken = default);
}
