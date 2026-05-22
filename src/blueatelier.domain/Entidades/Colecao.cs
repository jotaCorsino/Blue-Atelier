using System;

namespace BlueAtelier.Domain.Entidades;

public sealed class Colecao
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Nome { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Descricao { get; set; }

    public string? ImagemCapa { get; set; }

    public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;

    public bool EstaArquivada { get; set; }
}
