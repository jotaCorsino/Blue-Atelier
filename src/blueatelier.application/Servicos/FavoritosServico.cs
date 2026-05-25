using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Modelos;
using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Application.Servicos;

public sealed class FavoritosServico(
    IFavoritosRepositorio favoritosRepositorio) : IFavoritosServico
{
    public async Task<IReadOnlyList<FavoritoBarraItem>> ListarBarraAsync(
        CancellationToken cancellationToken = default)
    {
        var pastas = await favoritosRepositorio.ListarPastasAsync(cancellationToken);
        var links = await favoritosRepositorio.ListarLinksAsync(cancellationToken);

        var linksPorPasta = links
            .Where(link => link.PastaFavoritosId.HasValue)
            .GroupBy(link => link.PastaFavoritosId!.Value)
            .ToDictionary(grupo => grupo.Key, grupo => grupo.Count());

        var itens = pastas
            .Select(pasta => CriarItemPasta(pasta, linksPorPasta.GetValueOrDefault(pasta.Id)))
            .Concat(links.Select(CriarItemLink))
            .OrderBy(item => item.EhPasta ? 0 : 1)
            .ThenBy(item => item.Ordem)
            .ThenBy(item => item.Nome)
            .ToList();

        return itens;
    }

    private static FavoritoBarraItem CriarItemPasta(PastaFavoritos pasta, int quantidadeLinks)
    {
        return new FavoritoBarraItem(
            pasta.Id,
            "Pasta",
            pasta.Nome,
            "#",
            "folder",
            "folder",
            pasta.Id,
            pasta.Ordem,
            NormalizarTomVisual(pasta.TomVisual),
            quantidadeLinks);
    }

    private static FavoritoBarraItem CriarItemLink(LinkFavorito link)
    {
        return new FavoritoBarraItem(
            link.Id,
            "Link",
            link.Nome,
            link.Url,
            "link",
            string.IsNullOrWhiteSpace(link.Iniciais) ? CriarIniciais(link.Nome) : link.Iniciais,
            link.PastaFavoritosId,
            link.Ordem,
            NormalizarTomVisual(link.TomVisual));
    }

    private static string NormalizarTomVisual(string? tomVisual)
    {
        if (string.IsNullOrWhiteSpace(tomVisual))
        {
            return "blue";
        }

        return tomVisual.Trim().ToLowerInvariant() switch
        {
            "azul" => "blue",
            "cinza" => "slate",
            "vermelho" => "red",
            "rosa" => "rose",
            "verde" => "green",
            _ => tomVisual.Trim().ToLowerInvariant()
        };
    }

    private static string CriarIniciais(string nome)
    {
        var partes = nome
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Take(2)
            .Select(parte => char.ToUpperInvariant(parte[0]))
            .ToArray();

        return partes.Length == 0
            ? "?"
            : new string(partes);
    }
}
