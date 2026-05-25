namespace BlueAtelier.Application.Modelos;

public sealed record FavoritoBarraItem(
    Guid Id,
    string Tipo,
    string Nome,
    string Url,
    string Icone,
    string FaviconLocalOuTexto,
    Guid? PastaId,
    int Ordem,
    string TomVisual,
    int? QuantidadeLinks = null)
{
    public bool EhPasta => string.Equals(Tipo, "Pasta", StringComparison.OrdinalIgnoreCase);
}
