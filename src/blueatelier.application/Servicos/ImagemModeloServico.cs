using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Modelos;
using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Application.Servicos;

public sealed class ImagemModeloServico(
    IImagemModeloRepositorio imagemModeloRepositorio,
    IModeloServico modeloServico) : IImagemModeloServico
{
    private const string IdentificadorImagemPrincipal = "main-reference";

    public async Task<IReadOnlyList<ImagemModeloResumo>> ListarPorModeloAsync(
        Guid modeloId,
        CancellationToken cancellationToken = default)
    {
        var imagens = await imagemModeloRepositorio.ListarPorModeloAsync(modeloId, cancellationToken);

        return imagens
            .Select(CriarResumo)
            .ToList();
    }

    public async Task<ImagemModeloDetalhe?> ObterDetalheAsync(
        string colecaoSlug,
        string modeloSlug,
        string imagemSlug,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(colecaoSlug)
            || string.IsNullOrWhiteSpace(modeloSlug)
            || string.IsNullOrWhiteSpace(imagemSlug))
        {
            return null;
        }

        var modelo = await modeloServico.ObterDetalhePorSlugAsync(
            colecaoSlug,
            modeloSlug,
            cancellationToken);

        if (modelo is null)
        {
            return null;
        }

        var imagem = string.Equals(
            imagemSlug,
            IdentificadorImagemPrincipal,
            StringComparison.OrdinalIgnoreCase)
            ? await imagemModeloRepositorio.ObterPrincipalPorModeloAsync(modelo.Id, cancellationToken)
            : null;

        return imagem is null
            ? null
            : CriarDetalhe(imagem, modelo);
    }

    private static ImagemModeloResumo CriarResumo(ImagemDoModelo imagem)
    {
        return new ImagemModeloResumo(
            imagem.Id,
            imagem.ModeloId,
            imagem.Titulo,
            imagem.CaminhoLocal,
            imagem.Tipo,
            imagem.Ordem,
            imagem.EhPrincipal,
            imagem.Observacao,
            imagem.CriadoEm);
    }

    private static ImagemModeloDetalhe CriarDetalhe(
        ImagemDoModelo imagem,
        ModeloDetalhe modelo)
    {
        return new ImagemModeloDetalhe(
            imagem.Id,
            imagem.ModeloId,
            modelo.Nome,
            modelo.Slug,
            modelo.ColecaoNome,
            modelo.ColecaoSlug,
            imagem.Titulo,
            imagem.CaminhoLocal,
            imagem.Tipo,
            imagem.Ordem,
            imagem.EhPrincipal,
            imagem.Observacao,
            imagem.CriadoEm);
    }
}
