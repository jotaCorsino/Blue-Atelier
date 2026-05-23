using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Modelos;
using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Application.Servicos;

public sealed class ModeloServico(IModeloRepositorio modeloRepositorio) : IModeloServico
{
    public async Task<IReadOnlyList<ModeloResumoColecao>> ListarPorColecaoAsync(
        Guid colecaoId,
        CancellationToken cancellationToken = default)
    {
        var modelos = await modeloRepositorio.ListarPorColecaoAsync(colecaoId, cancellationToken);

        return modelos
            .Select(CriarResumo)
            .ToList();
    }

    private static ModeloResumoColecao CriarResumo(Modelo modelo)
    {
        return new ModeloResumoColecao(
            modelo.Id,
            modelo.ColecaoId,
            modelo.Nome,
            modelo.Slug,
            modelo.Descricao,
            modelo.EtapaAtual,
            modelo.ProgressoPercentual,
            modelo.TipoArquivo,
            modelo.Escala,
            modelo.TempoEstimado,
            modelo.MaterialSugerido,
            modelo.AtualizadoEm);
    }
}
