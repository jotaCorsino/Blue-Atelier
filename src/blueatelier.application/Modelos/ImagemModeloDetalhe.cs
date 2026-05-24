using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Application.Modelos;

public sealed record ImagemModeloDetalhe(
    Guid Id,
    Guid ModeloId,
    string ModeloNome,
    string ModeloSlug,
    string ColecaoNome,
    string ColecaoSlug,
    string Titulo,
    string CaminhoLocal,
    TipoImagemModelo Tipo,
    int Ordem,
    bool EhPrincipal,
    string? Observacao,
    DateTimeOffset CriadoEm);
