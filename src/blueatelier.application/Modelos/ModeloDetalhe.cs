using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Application.Modelos;

public sealed record ModeloDetalhe(
    Guid Id,
    Guid ColecaoId,
    string ColecaoNome,
    string ColecaoSlug,
    string Nome,
    string Slug,
    string? Descricao,
    EtapaModelo EtapaAtual,
    int ProgressoPercentual,
    string? TipoArquivo,
    string? Escala,
    string? TempoEstimado,
    string? MaterialSugerido,
    string? Observacoes,
    DateTimeOffset CriadoEm,
    DateTimeOffset AtualizadoEm);
