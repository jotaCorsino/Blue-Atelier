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
    private static readonly Guid DeepOneBustId = Guid.Parse("40df38fd-4c2a-4fd6-a08f-6181fbf21a05");
    private static readonly Guid TentacleBeastId = Guid.Parse("dc335f26-731d-449f-92ad-3f2e9dbcf704");
    private static readonly Guid AncientCultistId = Guid.Parse("9ecf77b5-e9f1-44d8-957b-6e8e9f39f3ce");
    private static readonly Guid ForgottenHorrorId = Guid.Parse("9a2e90c6-d5f5-4fa8-9088-0b4a1e3edac4");
    private static readonly Guid AbyssalStatueId = Guid.Parse("3d1e0b5a-3932-47a7-9f91-f40b50fd9077");
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

        await CriarModeloSeNaoExistirAsync(
            contexto,
            CthulhuIdolId,
            colecao.Id,
            "Cthulhu Idol",
            "cthulhu-idol",
            "Idolo principal da colecao, preparado para pintura em tons profundos.",
            EtapaModelo.Pintura,
            60,
            "STL",
            "32mm",
            "6h 20min",
            "Resin Grey",
            "Seed inicial para manter o Detalhe da Colecao visualmente preenchido.",
            agora.AddDays(-18),
            agora,
            cancellationToken);

        await CriarModeloSeNaoExistirAsync(
            contexto,
            DeepOneBustId,
            colecao.Id,
            "Deep One Bust",
            "deep-one-bust",
            "Busto anfibio para estudos de pele fria e brilho umido.",
            EtapaModelo.Impressao,
            25,
            "STL",
            "Bust",
            "4h 10min",
            "Resin Grey",
            "Seed visual para cards da colecao.",
            agora.AddDays(-16),
            agora.AddDays(-1),
            cancellationToken);

        await CriarModeloSeNaoExistirAsync(
            contexto,
            TentacleBeastId,
            colecao.Id,
            "Tentacle Beast",
            "tentacle-beast",
            "Criatura tentacular com base rochosa e volumes organicos.",
            EtapaModelo.Impressao,
            50,
            "STL",
            "32mm",
            "7h",
            "Resin Grey",
            "Seed visual para cards da colecao.",
            agora.AddDays(-15),
            agora.AddDays(-2),
            cancellationToken);

        await CriarModeloSeNaoExistirAsync(
            contexto,
            AncientCultistId,
            colecao.Id,
            "Ancient Cultist",
            "ancient-cultist",
            "Cultista finalizado para acompanhar os rituais da colecao.",
            EtapaModelo.Concluido,
            100,
            "STL",
            "28mm",
            "3h 30min",
            "Primer Black",
            "Seed visual para cards da colecao.",
            agora.AddDays(-24),
            agora.AddDays(-5),
            cancellationToken);

        await CriarModeloSeNaoExistirAsync(
            contexto,
            ForgottenHorrorId,
            colecao.Id,
            "Forgotten Horror",
            "forgotten-horror",
            "Forma esquecida em preparacao para impressao e pintura escura.",
            EtapaModelo.Impressao,
            25,
            "STL",
            "Large",
            "8h",
            "Resin Grey",
            "Seed visual para cards da colecao.",
            agora.AddDays(-20),
            agora.AddDays(-7),
            cancellationToken);

        await CriarModeloSeNaoExistirAsync(
            contexto,
            AbyssalStatueId,
            colecao.Id,
            "Abyssal Statue",
            "abyssal-statue",
            "Estatua de ruina submersa para estudos de pedra e limo.",
            EtapaModelo.Preparacao,
            30,
            "STL",
            "Terrain",
            "5h",
            "Resin Grey",
            "Seed visual para cards da colecao.",
            agora.AddDays(-12),
            agora.AddDays(-9),
            cancellationToken);

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

    private static async Task CriarModeloSeNaoExistirAsync(
        BlueAtelierDbContext contexto,
        Guid id,
        Guid colecaoId,
        string nome,
        string slug,
        string descricao,
        EtapaModelo etapaAtual,
        int progressoPercentual,
        string tipoArquivo,
        string escala,
        string tempoEstimado,
        string materialSugerido,
        string observacoes,
        DateTimeOffset criadoEm,
        DateTimeOffset atualizadoEm,
        CancellationToken cancellationToken)
    {
        var modeloExiste = await contexto.Modelos
            .AnyAsync(item => item.Slug == slug && item.ColecaoId == colecaoId, cancellationToken);

        if (modeloExiste)
        {
            return;
        }

        contexto.Modelos.Add(new Modelo
        {
            Id = id,
            ColecaoId = colecaoId,
            Nome = nome,
            Slug = slug,
            Descricao = descricao,
            EtapaAtual = etapaAtual,
            ProgressoPercentual = progressoPercentual,
            TipoArquivo = tipoArquivo,
            Escala = escala,
            TempoEstimado = tempoEstimado,
            MaterialSugerido = materialSugerido,
            Observacoes = observacoes,
            CriadoEm = criadoEm,
            AtualizadoEm = atualizadoEm
        });
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
