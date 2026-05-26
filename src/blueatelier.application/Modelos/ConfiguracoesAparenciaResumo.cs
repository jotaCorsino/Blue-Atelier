namespace BlueAtelier.Application.Modelos;

public sealed record ConfiguracoesAparenciaResumo(
    string Tema,
    string Densidade,
    string CorDestaque,
    DateTimeOffset UltimaAtualizacao);
