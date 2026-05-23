using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Application.Modelos;

public sealed record ArquivoVinculadoResumo(
    Guid Id,
    Guid ModeloId,
    string Nome,
    string CaminhoLocal,
    TipoArquivoVinculado Tipo,
    string Extensao,
    long? TamanhoBytes,
    DateTimeOffset CriadoEm,
    DateTimeOffset AtualizadoEm);
