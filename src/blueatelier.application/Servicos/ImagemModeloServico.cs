using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Modelos;
using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Application.Servicos;

public sealed class ImagemModeloServico(
    IImagemModeloRepositorio imagemModeloRepositorio) : IImagemModeloServico
{
    public async Task<IReadOnlyList<ImagemModeloResumo>> ListarPorModeloAsync(
        Guid modeloId,
        CancellationToken cancellationToken = default)
    {
        var imagens = await imagemModeloRepositorio.ListarPorModeloAsync(modeloId, cancellationToken);

        return imagens
            .Select(CriarResumo)
            .ToList();
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
}
