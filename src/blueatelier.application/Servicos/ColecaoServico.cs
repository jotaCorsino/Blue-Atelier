using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Modelos;
using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Application.Servicos;

public sealed class ColecaoServico(IColecaoRepositorio colecaoRepositorio) : IColecaoServico
{
    public async Task<IReadOnlyList<ColecaoResumo>> ListarResumoAsync(CancellationToken cancellationToken = default)
    {
        var colecoes = await colecaoRepositorio.ListarAsync(cancellationToken);

        return colecoes
            .Select(CriarResumo)
            .ToList();
    }

    public async Task<ColecaoDetalhe?> ObterDetalhePorSlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(slug))
        {
            return null;
        }

        var colecao = await colecaoRepositorio.ObterPorSlugAsync(slug, cancellationToken);

        return colecao is null
            ? null
            : CriarDetalhe(colecao);
    }

    private static ColecaoResumo CriarResumo(Colecao colecao)
    {
        return new ColecaoResumo(
            colecao.Id,
            colecao.Nome,
            colecao.Slug,
            colecao.Descricao,
            colecao.ImagemCapa,
            colecao.EstaArquivada,
            colecao.CriadoEm,
            colecao.AtualizadoEm);
    }

    private static ColecaoDetalhe CriarDetalhe(Colecao colecao)
    {
        return new ColecaoDetalhe(
            colecao.Id,
            colecao.Nome,
            colecao.Slug,
            colecao.Descricao,
            colecao.ImagemCapa,
            colecao.EstaArquivada,
            colecao.CriadoEm,
            colecao.AtualizadoEm);
    }
}
