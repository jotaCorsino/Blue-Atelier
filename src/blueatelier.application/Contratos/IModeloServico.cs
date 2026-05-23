using BlueAtelier.Application.Modelos;

namespace BlueAtelier.Application.Contratos;

public interface IModeloServico
{
    Task<IReadOnlyList<ModeloResumoColecao>> ListarPorColecaoAsync(
        Guid colecaoId,
        CancellationToken cancellationToken = default);
}
