using System;

namespace BlueAtelier.Domain.Entidades;

public sealed class ModeloPastas
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Nome { get; set; } = string.Empty;

    public string Estrutura { get; set; } = string.Empty;

    public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
}
