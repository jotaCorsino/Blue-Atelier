using System;

namespace BlueAtelier.Domain.Entidades;

public sealed class ConfiguracaoApp
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Chave { get; set; } = string.Empty;

    public string Valor { get; set; } = string.Empty;

    public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
}
