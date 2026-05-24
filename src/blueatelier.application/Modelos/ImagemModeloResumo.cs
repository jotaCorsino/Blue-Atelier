using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Application.Modelos;

public sealed record ImagemModeloResumo(
    Guid Id,
    Guid ModeloId,
    string Titulo,
    string CaminhoLocal,
    TipoImagemModelo Tipo,
    int Ordem,
    bool EhPrincipal,
    string? Observacao,
    DateTimeOffset CriadoEm);
