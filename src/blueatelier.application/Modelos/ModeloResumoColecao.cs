using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Application.Modelos;

public sealed record ModeloResumoColecao(
    Guid Id,
    Guid ColecaoId,
    string Nome,
    string Slug,
    string? Descricao,
    EtapaModelo EtapaAtual,
    int ProgressoPercentual,
    string? TipoArquivo,
    string? Escala,
    string? TempoEstimado,
    string? MaterialSugerido,
    DateTimeOffset AtualizadoEm);
