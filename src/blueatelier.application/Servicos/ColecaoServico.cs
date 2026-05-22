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
}
