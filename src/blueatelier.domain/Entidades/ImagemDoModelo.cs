using System;
using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Domain.Entidades;

public sealed class ImagemDoModelo
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid ModeloId { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string CaminhoLocal { get; set; } = string.Empty;

    public TipoImagemModelo Tipo { get; set; } = TipoImagemModelo.Referencia;

    public int Ordem { get; set; }

    public bool EhPrincipal { get; set; }

    public string? Observacao { get; set; }

    public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;
}
