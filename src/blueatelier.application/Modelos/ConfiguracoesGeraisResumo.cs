namespace BlueAtelier.Application.Modelos;

public sealed record ConfiguracoesGeraisResumo(
    string Idioma,
    string Tema,
    string Densidade,
    string CorDestaque,
    string DiretorioRaiz,
    string DiretorioModelos,
    string DiretorioBackups,
    bool BackupAutomatico,
    DateTimeOffset UltimaAtualizacao);
