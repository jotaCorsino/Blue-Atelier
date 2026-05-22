using System;
using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Domain.Entidades;

public sealed class Modelo
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid ColecaoId { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Descricao { get; set; }

    public EtapaModelo EtapaAtual { get; set; } = EtapaModelo.Ideia;

    public int ProgressoPercentual { get; set; }

    public string? TipoArquivo { get; set; }

    public string? Escala { get; set; }

    public string? TempoEstimado { get; set; }

    public string? MaterialSugerido { get; set; }

    public string? Observacoes { get; set; }

    public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
}
