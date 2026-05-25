namespace BlueAtelier.Application.Modelos;

public sealed record BuscaResultado(
    Guid Id,
    string Tipo,
    string Titulo,
    string Descricao,
    string Contexto,
    string? Rota,
    string Icone,
    string TomVisual,
    int Relevancia,
    DateTimeOffset AtualizadoEm);
