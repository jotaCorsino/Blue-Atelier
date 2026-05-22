using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Infrastructure.Persistencia;

public static class BlueAtelierSeed
{
    private static readonly Guid EldritchHorrorsId = Guid.Parse("7d705b6c-67da-49f6-a8bf-4c9fc0dbd1a0");
    private static readonly Guid SciFiMarinesId = Guid.Parse("8a91a51e-bc24-4650-a11f-b58fce34c628");
    private static readonly Guid FantasyAdventurersId = Guid.Parse("91cbd5aa-8ea4-44f9-86ad-72a6e7ab1c7d");
    private static readonly Guid DragonBustsId = Guid.Parse("4570cf1e-34a5-4e1f-9b95-6bb8f340ff3c");
    private static readonly Guid TavernDioramasId = Guid.Parse("b45f39d0-557b-4ad6-b08c-2ed49c57732f");
    private static readonly Guid AncientRuinsId = Guid.Parse("0ec02f89-54bb-4f1b-93ef-95c0856b6b71");
    private static readonly Guid PaintingStudiesId = Guid.Parse("da56b088-8ea8-4a86-a11f-9af2db32b526");
    private static readonly Guid MiniatureBasesId = Guid.Parse("b364b206-02d9-4c92-b93d-73f5a77798d7");
    private static readonly Guid CthulhuIdolId = Guid.Parse("1dc6625f-853a-43b8-a6f5-7be26f8a7c87");
    private static readonly Guid ReferenciasFavoritasId = Guid.Parse("f07ac854-b9f3-4d1c-b033-e4803b5241a5");

    public static async Task AplicarAsync(BlueAtelierDbContext contexto, CancellationToken cancellationToken = default)
    {
        var agora = DateTimeOffset.UtcNow;
        var colecao = await CriarColecaoSeNaoExistirAsync(
            contexto,
            EldritchHorrorsId,
            "Eldritch Horrors",
            "eldritch-horrors",
            "Miniaturas sombrias, \u00eddolos antigos e criaturas de culto.",
            "cover-eldritch",
            agora.AddDays(-40),
            agora,
            false,
            cancellationToken);

        await CriarColecaoSeNaoExistirAsync(
            contexto,
            SciFiMarinesId,
            "Sci-Fi Marines",
            "sci-fi-marines",
            "Soldados blindados, armas pesadas e varia\u00e7\u00f5es de tropa.",
            "cover-marines",
            agora.AddDays(-35),
            agora.AddDays(-1),
            false,
            cancellationToken);

        await CriarColecaoSeNaoExistirAsync(
            contexto,
            FantasyAdventurersId,
            "Fantasy Adventurers",
            "fantasy-adventurers",
            "Grupo de aventureiros para pintura e estudos de personagem.",
            "cover-adventurers",
            agora.AddDays(-28),
            agora.AddDays(-3),
            false,
            cancellationToken);

        await CriarColecaoSeNaoExistirAsync(
            contexto,
            DragonBustsId,
            "Dragon Busts",
            "dragon-busts",
            "Bustos de drag\u00f5es para escala maior e acabamento detalhado.",
            "cover-dragons",
            agora.AddDays(-24),
            agora.AddDays(-5),
            false,
            cancellationToken);

        await CriarColecaoSeNaoExistirAsync(
            contexto,
            TavernDioramasId,
            "Tavern Dioramas",
            "tavern-dioramas",
            "Cenas internas, fachadas e pe\u00e7as para dioramas de taverna.",
            "cover-tavern",
            agora.AddDays(-22),
            agora.AddDays(-7),
            false,
            cancellationToken);

        await CriarColecaoSeNaoExistirAsync(
            contexto,
            AncientRuinsId,
            "Ancient Ruins",
            "ancient-ruins",
            "Pilares, arcos e bases para composi\u00e7\u00f5es de ru\u00ednas antigas.",
            "cover-ruins",
            agora.AddDays(-20),
            agora.AddDays(-8),
            false,
            cancellationToken);

        await CriarColecaoSeNaoExistirAsync(
            contexto,
            PaintingStudiesId,
            "Painting Studies",
            "painting-studies",
            "Pe\u00e7as separadas para testes de pedra, pele, metal e verniz.",
            "cover-painting",
            agora.AddDays(-18),
            agora.AddDays(-14),
            false,
            cancellationToken);

        await CriarColecaoSeNaoExistirAsync(
            contexto,
            MiniatureBasesId,
            "Miniature Bases",
            "miniature-bases",
            "Bases tem\u00e1ticas para miniaturas pequenas e m\u00e9dias.",
            "cover-bases",
            agora.AddDays(-60),
            agora.AddMonths(-1),
            true,
            cancellationToken);

        var modeloExiste = await contexto.Modelos
            .AnyAsync(item => item.Slug == "cthulhu-idol" && item.ColecaoId == colecao.Id, cancellationToken);

        if (!modeloExiste)
        {
            contexto.Modelos.Add(new Modelo
            {
                Id = CthulhuIdolId,
                ColecaoId = colecao.Id,
                Nome = "Cthulhu Idol",
                Slug = "cthulhu-idol",
                Descricao = "Modelo inicial para seed minimo do Blue Atelier.",
                EtapaAtual = EtapaModelo.Pintura,
                ProgressoPercentual = 72,
                TipoArquivo = "STL",
                Escala = "32mm",
                TempoEstimado = "6h 20min",
                MaterialSugerido = "Resin Grey",
                Observacoes = "Seed inicial; ainda nao conectado a UI.",
                CriadoEm = agora,
                AtualizadoEm = agora
            });
        }

        var pastaExiste = await contexto.PastasFavoritos
            .AnyAsync(item => item.Nome == "Referencias", cancellationToken);

        if (!pastaExiste)
        {
            contexto.PastasFavoritos.Add(new PastaFavoritos
            {
                Id = ReferenciasFavoritasId,
                Nome = "Referencias",
                TomVisual = "azul",
                Ordem = 1,
                CriadoEm = agora,
                AtualizadoEm = agora
            });
        }

        await CriarLinkFavoritoSeNaoExistirAsync(
            contexto,
            "ArtStation",
            "https://www.artstation.com",
            "AS",
            ReferenciasFavoritasId,
            1,
            agora,
            cancellationToken);

        await CriarLinkFavoritoSeNaoExistirAsync(
            contexto,
            "Thingiverse",
            "https://www.thingiverse.com",
            "TH",
            ReferenciasFavoritasId,
            2,
            agora,
            cancellationToken);

        var configuracaoExiste = await contexto.ConfiguracoesApp
            .AnyAsync(item => item.Chave == "app.idioma", cancellationToken);

        if (!configuracaoExiste)
        {
            contexto.ConfiguracoesApp.Add(new ConfiguracaoApp
            {
                Chave = "app.idioma",
                Valor = "pt-BR",
                AtualizadoEm = agora
            });
        }

        await contexto.SaveChangesAsync(cancellationToken);
    }

    private static async Task<Colecao> CriarColecaoSeNaoExistirAsync(
        BlueAtelierDbContext contexto,
        Guid id,
        string nome,
        string slug,
        string descricao,
        string imagemCapa,
        DateTimeOffset criadoEm,
        DateTimeOffset atualizadoEm,
        bool estaArquivada,
        CancellationToken cancellationToken)
    {
        var colecao = await contexto.Colecoes
            .SingleOrDefaultAsync(item => item.Slug == slug, cancellationToken);

        if (colecao is not null)
        {
            return colecao;
        }

        colecao = new Colecao
        {
            Id = id,
            Nome = nome,
            Slug = slug,
            Descricao = descricao,
            ImagemCapa = imagemCapa,
            CriadoEm = criadoEm,
            AtualizadoEm = atualizadoEm,
            EstaArquivada = estaArquivada
        };

        contexto.Colecoes.Add(colecao);

        return colecao;
    }

    private static async Task CriarLinkFavoritoSeNaoExistirAsync(
        BlueAtelierDbContext contexto,
        string nome,
        string url,
        string iniciais,
        Guid pastaId,
        int ordem,
        DateTimeOffset agora,
        CancellationToken cancellationToken)
    {
        var linkExiste = await contexto.LinksFavoritos
            .AnyAsync(item => item.Url == url, cancellationToken);

        if (linkExiste)
        {
            return;
        }

        contexto.LinksFavoritos.Add(new LinkFavorito
        {
            PastaFavoritosId = pastaId,
            Nome = nome,
            Url = url,
            Iniciais = iniciais,
            TomVisual = "azul",
            Ordem = ordem,
            CriadoEm = agora,
            AtualizadoEm = agora
        });
    }
}
