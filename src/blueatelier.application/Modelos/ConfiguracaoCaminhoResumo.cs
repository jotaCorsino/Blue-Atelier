namespace BlueAtelier.Application.Modelos;

public sealed record ConfiguracaoCaminhoResumo(
    Guid Id,
    string Nome,
    string Tipo,
    string Caminho,
    string Descricao,
    string StatusVisual,
    bool EhObrigatorio,
    DateTimeOffset AtualizadoEm);
