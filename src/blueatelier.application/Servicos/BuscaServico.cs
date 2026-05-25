using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Modelos;
using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Application.Servicos;

public sealed class BuscaServico(
    IColecaoRepositorio colecaoRepositorio,
    IModeloRepositorio modeloRepositorio,
    IArquivoVinculadoRepositorio arquivoVinculadoRepositorio,
    IImagemModeloRepositorio imagemModeloRepositorio,
    IFavoritosRepositorio favoritosRepositorio) : IBuscaServico
{
    private const int LimiteResultados = 12;

    public async Task<IReadOnlyList<BuscaResultado>> BuscarAsync(
        string termo,
        CancellationToken cancellationToken = default)
    {
        var termoNormalizado = termo.Trim();
        var colecoes = await colecaoRepositorio.ListarAsync(cancellationToken);
        var modelos = await modeloRepositorio.ListarAsync(cancellationToken);
        var arquivos = await arquivoVinculadoRepositorio.ListarAsync(cancellationToken);
        var imagens = await imagemModeloRepositorio.ListarAsync(cancellationToken);
        var linksFavoritos = await favoritosRepositorio.ListarLinksAsync(cancellationToken);
        var pastasFavoritos = await favoritosRepositorio.ListarPastasAsync(cancellationToken);

        var colecoesPorId = colecoes.ToDictionary(colecao => colecao.Id);
        var modelosPorId = modelos.ToDictionary(modelo => modelo.Id);

        var resultados = CriarResultados(
                termoNormalizado,
                colecoes,
                modelos,
                arquivos,
                imagens,
                linksFavoritos,
                pastasFavoritos,
                colecoesPorId,
                modelosPorId)
            .ToList();

        if (string.IsNullOrWhiteSpace(termoNormalizado))
        {
            return resultados
                .GroupBy(resultado => resultado.Tipo)
                .SelectMany(grupo => grupo
                    .OrderByDescending(resultado => resultado.AtualizadoEm)
                    .ThenBy(resultado => resultado.Titulo)
                    .Take(QuantidadeInicialPorTipo(grupo.Key)))
                .OrderBy(resultado => PrioridadeTipo(resultado.Tipo))
                .ThenByDescending(resultado => resultado.AtualizadoEm)
                .ThenBy(resultado => resultado.Titulo)
                .Take(LimiteResultados)
                .ToList();
        }

        return resultados
            .OrderByDescending(resultado => resultado.Relevancia)
            .ThenByDescending(resultado => resultado.AtualizadoEm)
            .ThenBy(resultado => resultado.Titulo)
            .Take(LimiteResultados)
            .ToList();
    }

    private static IEnumerable<BuscaResultado> CriarResultados(
        string termo,
        IReadOnlyList<Colecao> colecoes,
        IReadOnlyList<Modelo> modelos,
        IReadOnlyList<ArquivoVinculado> arquivos,
        IReadOnlyList<ImagemDoModelo> imagens,
        IReadOnlyList<LinkFavorito> linksFavoritos,
        IReadOnlyList<PastaFavoritos> pastasFavoritos,
        IReadOnlyDictionary<Guid, Colecao> colecoesPorId,
        IReadOnlyDictionary<Guid, Modelo> modelosPorId)
    {
        foreach (var colecao in colecoes)
        {
            if (Corresponde(termo, colecao.Nome, colecao.Slug, colecao.Descricao))
            {
                yield return new BuscaResultado(
                    colecao.Id,
                    "Colecao",
                    colecao.Nome,
                    TextoOuPadrao(colecao.Descricao, "Colecao registrada no atelier."),
                    "Colecoes",
                    $"/colecoes/{colecao.Slug}",
                    "collections",
                    "blue",
                    CalcularRelevancia(termo, colecao.Nome, colecao.Slug, colecao.Descricao),
                    colecao.AtualizadoEm);
            }
        }

        foreach (var modelo in modelos)
        {
            colecoesPorId.TryGetValue(modelo.ColecaoId, out var colecao);

            if (Corresponde(
                termo,
                modelo.Nome,
                modelo.Slug,
                modelo.Descricao,
                modelo.EtapaAtual.ToString(),
                modelo.Escala,
                modelo.MaterialSugerido))
            {
                yield return new BuscaResultado(
                    modelo.Id,
                    "Modelo",
                    modelo.Nome,
                    TextoOuPadrao(modelo.Descricao, "Modelo registrado no atelier."),
                    colecao?.Nome ?? "Colecao sem nome",
                    CriarRotaModelo(colecao, modelo),
                    "models",
                    "blue",
                    CalcularRelevancia(
                        termo,
                        modelo.Nome,
                        modelo.Slug,
                        modelo.Descricao,
                        modelo.EtapaAtual.ToString(),
                        modelo.Escala,
                        modelo.MaterialSugerido),
                    modelo.AtualizadoEm);
            }
        }

        foreach (var arquivo in arquivos)
        {
            modelosPorId.TryGetValue(arquivo.ModeloId, out var modelo);
            var colecao = modelo is not null && colecoesPorId.TryGetValue(modelo.ColecaoId, out var colecaoEncontrada)
                ? colecaoEncontrada
                : null;

            if (Corresponde(
                termo,
                arquivo.Nome,
                arquivo.Extensao,
                arquivo.Tipo.ToString(),
                arquivo.CaminhoLocal))
            {
                yield return new BuscaResultado(
                    arquivo.Id,
                    "Arquivo",
                    arquivo.Nome,
                    $"{arquivo.Tipo} {arquivo.Extensao}".Trim(),
                    modelo?.Nome ?? "Arquivos vinculados",
                    CriarRotaArquivos(colecao, modelo),
                    "folder",
                    "slate",
                    CalcularRelevancia(
                        termo,
                        arquivo.Nome,
                        arquivo.Extensao,
                        arquivo.Tipo.ToString(),
                        arquivo.CaminhoLocal),
                    arquivo.CriadoEm);
            }
        }

        foreach (var imagem in imagens)
        {
            modelosPorId.TryGetValue(imagem.ModeloId, out var modelo);
            var colecao = modelo is not null && colecoesPorId.TryGetValue(modelo.ColecaoId, out var colecaoEncontrada)
                ? colecaoEncontrada
                : null;

            if (Corresponde(
                termo,
                imagem.Titulo,
                imagem.Tipo.ToString(),
                imagem.Observacao,
                imagem.CaminhoLocal))
            {
                yield return new BuscaResultado(
                    imagem.Id,
                    "Imagem",
                    imagem.Titulo,
                    TextoOuPadrao(imagem.Observacao, imagem.Tipo.ToString()),
                    modelo is null ? "Galeria" : $"Galeria do {modelo.Nome}",
                    CriarRotaImagem(colecao, modelo, imagem),
                    "image",
                    "slate",
                    CalcularRelevancia(
                        termo,
                        imagem.Titulo,
                        imagem.Tipo.ToString(),
                        imagem.Observacao,
                        imagem.CaminhoLocal),
                    imagem.CriadoEm);
            }
        }

        foreach (var pasta in pastasFavoritos)
        {
            if (Corresponde(termo, pasta.Nome))
            {
                yield return new BuscaResultado(
                    pasta.Id,
                    "Favorito",
                    pasta.Nome,
                    "Pasta de favoritos.",
                    "Favoritos",
                    "/favoritos",
                    "favorites",
                    NormalizarTomVisual(pasta.TomVisual),
                    CalcularRelevancia(termo, pasta.Nome),
                    pasta.AtualizadoEm);
            }
        }

        foreach (var link in linksFavoritos)
        {
            if (Corresponde(termo, link.Nome, link.Url, link.Iniciais))
            {
                yield return new BuscaResultado(
                    link.Id,
                    "Favorito",
                    link.Nome,
                    link.Url,
                    "Favoritos",
                    "/favoritos",
                    "favorites",
                    NormalizarTomVisual(link.TomVisual),
                    CalcularRelevancia(termo, link.Nome, link.Url, link.Iniciais),
                    link.AtualizadoEm);
            }
        }
    }

    private static bool Corresponde(string termo, params string?[] campos)
    {
        return string.IsNullOrWhiteSpace(termo)
            || campos.Any(campo =>
                !string.IsNullOrWhiteSpace(campo)
                && campo.Contains(termo, StringComparison.OrdinalIgnoreCase));
    }

    private static int CalcularRelevancia(string termo, string titulo, params string?[] campos)
    {
        if (string.IsNullOrWhiteSpace(termo))
        {
            return 70;
        }

        if (titulo.Contains(termo, StringComparison.OrdinalIgnoreCase))
        {
            return 98;
        }

        return campos.Any(campo =>
            !string.IsNullOrWhiteSpace(campo)
            && campo.Contains(termo, StringComparison.OrdinalIgnoreCase))
            ? 84
            : 60;
    }

    private static int QuantidadeInicialPorTipo(string tipo)
    {
        return tipo switch
        {
            "Modelo" => 3,
            "Colecao" => 2,
            "Arquivo" => 2,
            "Imagem" => 2,
            "Favorito" => 3,
            _ => 1
        };
    }

    private static int PrioridadeTipo(string tipo)
    {
        return tipo switch
        {
            "Modelo" => 0,
            "Colecao" => 1,
            "Imagem" => 2,
            "Arquivo" => 3,
            "Favorito" => 4,
            _ => 5
        };
    }

    private static string TextoOuPadrao(string? valor, string padrao)
    {
        return string.IsNullOrWhiteSpace(valor) ? padrao : valor;
    }

    private static string? CriarRotaModelo(Colecao? colecao, Modelo modelo)
    {
        return colecao is null || string.IsNullOrWhiteSpace(colecao.Slug) || string.IsNullOrWhiteSpace(modelo.Slug)
            ? null
            : $"/colecoes/{colecao.Slug}/modelos/{modelo.Slug}";
    }

    private static string? CriarRotaArquivos(Colecao? colecao, Modelo? modelo)
    {
        return colecao is null || modelo is null
            ? null
            : $"/colecoes/{colecao.Slug}/modelos/{modelo.Slug}/arquivos";
    }

    private static string? CriarRotaImagem(Colecao? colecao, Modelo? modelo, ImagemDoModelo imagem)
    {
        if (colecao is null || modelo is null)
        {
            return null;
        }

        var rotaGaleria = $"/colecoes/{colecao.Slug}/modelos/{modelo.Slug}/galeria";

        return imagem.EhPrincipal
            ? $"{rotaGaleria}/main-reference"
            : rotaGaleria;
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
}
