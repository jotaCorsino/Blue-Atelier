namespace BlueAtelier.Application.Modelos;

public sealed record ModeloPastasItemResumo(
    string Nome,
    string CaminhoRelativo,
    int Nivel,
    string Tipo,
    int Ordem,
    bool EhObrigatorio);
