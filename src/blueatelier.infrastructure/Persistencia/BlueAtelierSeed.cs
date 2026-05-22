using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Infrastructure.Persistencia;

public static class BlueAtelierSeed
{
    private static readonly Guid EldritchHorrorsId = Guid.Parse("7d705b6c-67da-49f6-a8bf-4c9fc0dbd1a0");
    private static readonly Guid CthulhuIdolId = Guid.Parse("1dc6625f-853a-43b8-a6f5-7be26f8a7c87");
    private static readonly Guid ReferenciasFavoritasId = Guid.Parse("f07ac854-b9f3-4d1c-b033-e4803b5241a5");

    public static async Task AplicarAsync(BlueAtelierDbContext contexto, CancellationToken cancellationToken = default)
    {
        var agora = DateTimeOffset.UtcNow;
        var colecao = await contexto.Colecoes
            .SingleOrDefaultAsync(item => item.Slug == "eldritch-horrors", cancellationToken);

        if (colecao is null)
        {
            colecao = new Colecao
            {
                Id = EldritchHorrorsId,
                Nome = "Eldritch Horrors",
                Slug = "eldritch-horrors",
                Descricao = "Colecao inicial mockada para validar a persistencia local.",
                ImagemCapa = "eldritch-horrors-cover",
                CriadoEm = agora,
                AtualizadoEm = agora
            };

            contexto.Colecoes.Add(colecao);
        }

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
