using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Modelos;
using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Application.Servicos;

public sealed class ModeloServico(
    IModeloRepositorio modeloRepositorio,
    IColecaoRepositorio colecaoRepositorio) : IModeloServico
{
    public async Task<IReadOnlyList<ModeloResumo>> ListarResumoAsync(CancellationToken cancellationToken = default)
    {
        var modelos = await modeloRepositorio.ListarAsync(cancellationToken);
        var colecoes = await colecaoRepositorio.ListarAsync(cancellationToken);
        var colecoesPorId = colecoes.ToDictionary(colecao => colecao.Id);

        return modelos
            .Select(modelo => CriarResumo(modelo, colecoesPorId.GetValueOrDefault(modelo.ColecaoId)))
            .ToList();
    }

    public async Task<IReadOnlyList<ModeloResumoColecao>> ListarPorColecaoAsync(
        Guid colecaoId,
        CancellationToken cancellationToken = default)
    {
        var modelos = await modeloRepositorio.ListarPorColecaoAsync(colecaoId, cancellationToken);

        return modelos
            .Select(CriarResumo)
            .ToList();
    }

    public async Task<ModeloDetalhe?> ObterDetalhePorSlugAsync(
        string colecaoSlug,
        string modeloSlug,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(colecaoSlug) || string.IsNullOrWhiteSpace(modeloSlug))
        {
            return null;
        }

        var colecao = await colecaoRepositorio.ObterPorSlugAsync(colecaoSlug, cancellationToken);

        if (colecao is null)
        {
            return null;
        }

        var modelo = await modeloRepositorio.ObterPorColecaoESlugAsync(
            colecao.Id,
            modeloSlug,
            cancellationToken);

        return modelo is null
            ? null
            : CriarDetalhe(modelo, colecao);
    }

    private static ModeloResumo CriarResumo(Modelo modelo, Colecao? colecao)
    {
        return new ModeloResumo(
            modelo.Id,
            modelo.ColecaoId,
            colecao?.Nome ?? "Colecao sem nome",
            colecao?.Slug ?? string.Empty,
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

    private static ModeloDetalhe CriarDetalhe(Modelo modelo, Colecao colecao)
    {
        return new ModeloDetalhe(
            modelo.Id,
            modelo.ColecaoId,
            colecao.Nome,
            colecao.Slug,
            modelo.Nome,
            modelo.Slug,
            modelo.Descricao,
            modelo.EtapaAtual,
            modelo.ProgressoPercentual,
            modelo.TipoArquivo,
            modelo.Escala,
            modelo.TempoEstimado,
            modelo.MaterialSugerido,
            modelo.Observacoes,
            modelo.CriadoEm,
            modelo.AtualizadoEm);
    }
}
