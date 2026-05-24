using BlueAtelier.Application.Modelos;

namespace BlueAtelier.Application.Contratos;

public interface IImagemModeloServico
{
    Task<IReadOnlyList<ImagemModeloResumo>> ListarPorModeloAsync(
        Guid modeloId,
        CancellationToken cancellationToken = default);
}
