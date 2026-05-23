using BlueAtelier.Application.Modelos;

namespace BlueAtelier.Application.Contratos;

public interface IArquivoVinculadoServico
{
    Task<IReadOnlyList<ArquivoVinculadoResumo>> ListarPorModeloAsync(
        Guid modeloId,
        CancellationToken cancellationToken = default);
}
