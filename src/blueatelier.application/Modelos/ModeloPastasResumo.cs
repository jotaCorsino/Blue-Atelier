namespace BlueAtelier.Application.Modelos;

public sealed record ModeloPastasResumo(
    Guid Id,
    string Nome,
    string Descricao,
    string Estrutura,
    IReadOnlyList<ModeloPastasItemResumo> Itens,
    DateTimeOffset AtualizadoEm);
