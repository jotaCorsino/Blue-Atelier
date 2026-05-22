namespace BlueAtelier.Application.Modelos;

public sealed record ColecaoResumo(
    Guid Id,
    string Nome,
    string Slug,
    string? Descricao,
    string? ImagemCapa,
    bool EstaArquivada,
    DateTimeOffset CriadoEm,
    DateTimeOffset AtualizadoEm);
