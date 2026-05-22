using System;
using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Domain.Entidades;

public sealed class ArquivoVinculado
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid ModeloId { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string CaminhoLocal { get; set; } = string.Empty;

    public TipoArquivoVinculado Tipo { get; set; } = TipoArquivoVinculado.Desconhecido;

    public string Extensao { get; set; } = string.Empty;

    public long? TamanhoBytes { get; set; }

    public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;
}
