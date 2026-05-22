using System;

namespace BlueAtelier.Domain.Entidades;

public sealed class PastaFavoritos
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Nome { get; set; } = string.Empty;

    public string? TomVisual { get; set; }

    public int Ordem { get; set; }

    public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
}
