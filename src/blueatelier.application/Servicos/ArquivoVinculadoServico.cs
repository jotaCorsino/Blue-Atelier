using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Modelos;
using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Application.Servicos;

public sealed class ArquivoVinculadoServico(
    IArquivoVinculadoRepositorio arquivoVinculadoRepositorio) : IArquivoVinculadoServico
{
    public async Task<IReadOnlyList<ArquivoVinculadoResumo>> ListarResumoAsync(
        CancellationToken cancellationToken = default)
    {
        var arquivos = await arquivoVinculadoRepositorio.ListarAsync(cancellationToken);

        return arquivos
            .Select(CriarResumo)
            .ToList();
    }

    public async Task<IReadOnlyList<ArquivoVinculadoResumo>> ListarPorModeloAsync(
        Guid modeloId,
        CancellationToken cancellationToken = default)
    {
        var arquivos = await arquivoVinculadoRepositorio.ListarPorModeloAsync(modeloId, cancellationToken);

        return arquivos
            .Select(CriarResumo)
            .ToList();
    }

    private static ArquivoVinculadoResumo CriarResumo(ArquivoVinculado arquivo)
    {
        return new ArquivoVinculadoResumo(
            arquivo.Id,
            arquivo.ModeloId,
            arquivo.Nome,
            arquivo.CaminhoLocal,
            arquivo.Tipo,
            arquivo.Extensao,
            arquivo.TamanhoBytes,
            arquivo.CriadoEm,
            arquivo.CriadoEm);
    }
}
