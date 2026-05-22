using System;
using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Domain.Entidades;

public sealed class CaminhoConfigurado
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Nome { get; set; } = string.Empty;

    public string Caminho { get; set; } = string.Empty;

    public TipoCaminhoConfigurado Tipo { get; set; } = TipoCaminhoConfigurado.Outro;

    public bool EstaAtivo { get; set; } = true;

    public DateTimeOffset AtualizadoEm { get; set; } = DateTimeOffset.UtcNow;
}
