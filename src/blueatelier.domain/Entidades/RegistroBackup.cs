using System;
using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Domain.Entidades;

public sealed class RegistroBackup
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Caminho { get; set; } = string.Empty;

    public long TamanhoBytes { get; set; }

    public DateTimeOffset CriadoEm { get; set; } = DateTimeOffset.UtcNow;

    public StatusBackup Status { get; set; } = StatusBackup.Pendente;
}
