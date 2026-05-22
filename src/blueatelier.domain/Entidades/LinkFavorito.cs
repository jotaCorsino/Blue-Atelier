using System;

namespace BlueAtelier.Domain.Entidades;

public sealed class LinkFavorito
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid? PastaFavoritosId { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public string? Iniciais { get; set; }

    public string? TomVisual { get; set; }

    public int Ordem { get; set; }

    public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
}
