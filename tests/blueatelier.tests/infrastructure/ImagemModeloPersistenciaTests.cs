using BlueAtelier.Application.Modelos;
using BlueAtelier.Application.Servicos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;
using BlueAtelier.Infrastructure.Persistencia;
using BlueAtelier.Infrastructure.Repositorios;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Tests.Infrastructure;

public sealed class ImagemModeloPersistenciaTests
{
    [Fact]
    public async Task Repositorio_DeveListarImagensDoModeloCorreto()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var modeloId = Guid.NewGuid();
            var outroModeloId = Guid.NewGuid();

            await CriarModeloComImagensAsync(opcoes, modeloId, outroModeloId);

            var repositorio = new ImagemModeloRepositorio(new TestDbContextFactory(opcoes));

            var imagens = await repositorio.ListarPorModeloAsync(modeloId);

            Assert.Equal(2, imagens.Count);
            Assert.All(imagens, imagem => Assert.Equal(modeloId, imagem.ModeloId));
            Assert.Contains(imagens, imagem => imagem.Titulo == "Main reference");
            Assert.Contains(imagens, imagem => imagem.Titulo == "Primer test");
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Repositorio_NaoDeveMisturarImagensDeOutroModelo()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var modeloId = Guid.NewGuid();
            var outroModeloId = Guid.NewGuid();

            await CriarModeloComImagensAsync(opcoes, modeloId, outroModeloId);

            var repositorio = new ImagemModeloRepositorio(new TestDbContextFactory(opcoes));

            var imagens = await repositorio.ListarPorModeloAsync(modeloId);

            Assert.DoesNotContain(imagens, imagem => imagem.Titulo == "Ruined arch front");
            Assert.DoesNotContain(imagens, imagem => imagem.ModeloId == outroModeloId);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Repositorio_DeveObterImagemPrincipalDoModeloCorreto()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var modeloId = Guid.NewGuid();
            var outroModeloId = Guid.NewGuid();

            await CriarModeloComImagensAsync(opcoes, modeloId, outroModeloId);

            var repositorio = new ImagemModeloRepositorio(new TestDbContextFactory(opcoes));

            var imagem = await repositorio.ObterPrincipalPorModeloAsync(modeloId);

            Assert.NotNull(imagem);
            Assert.Equal(modeloId, imagem.ModeloId);
            Assert.Equal("Main reference", imagem.Titulo);
            Assert.True(imagem.EhPrincipal);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Repositorio_NaoDeveMisturarImagemPrincipalDeOutroModelo()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var modeloId = Guid.NewGuid();
            var outroModeloId = Guid.NewGuid();

            await CriarModeloComImagensAsync(opcoes, modeloId, outroModeloId);

            var repositorio = new ImagemModeloRepositorio(new TestDbContextFactory(opcoes));

            var imagem = await repositorio.ObterPrincipalPorModeloAsync(outroModeloId);

            Assert.NotNull(imagem);
            Assert.Equal(outroModeloId, imagem.ModeloId);
            Assert.Equal("Ruined arch front", imagem.Titulo);
            Assert.NotEqual("Main reference", imagem.Titulo);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarResumoDeImagensDoModelo()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var modeloId = Guid.NewGuid();
            var outroModeloId = Guid.NewGuid();

            await CriarModeloComImagensAsync(opcoes, modeloId, outroModeloId);

            var repositorio = new ImagemModeloRepositorio(new TestDbContextFactory(opcoes));
            var servico = CriarImagemModeloServico(opcoes, repositorio);

            var resumos = await servico.ListarPorModeloAsync(modeloId);

            var resumo = Assert.Single(resumos, imagem => imagem.Titulo == "Main reference");
            Assert.IsType<ImagemModeloResumo>(resumo);
            Assert.IsNotType<ImagemDoModelo>(resumo);
            Assert.Equal(modeloId, resumo.ModeloId);
            Assert.Equal(TipoImagemModelo.Referencia, resumo.Tipo);
            Assert.True(resumo.EhPrincipal);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Seed_DeveCriarImagensDoCthulhuIdolSemDuplicar()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                await BlueAtelierSeed.AplicarAsync(contexto);
                await BlueAtelierSeed.AplicarAsync(contexto);
            }

            await using var consulta = new BlueAtelierDbContext(opcoes);
            var modelo = await consulta.Modelos.SingleAsync(item => item.Slug == "cthulhu-idol");
            var imagens = await consulta.ImagensDoModelo
                .Where(imagem => imagem.ModeloId == modelo.Id)
                .Select(imagem => imagem.CaminhoLocal)
                .ToListAsync();

            Assert.Equal(5, imagens.Count);
            Assert.Contains("C:/BlueAtelier/EldritchHorrors/CthulhuIdol/gallery/cthulhu-idol-front.jpg", imagens);
            Assert.Contains("C:/BlueAtelier/EldritchHorrors/CthulhuIdol/gallery/cthulhu-idol-side.jpg", imagens);
            Assert.Contains("C:/BlueAtelier/EldritchHorrors/CthulhuIdol/gallery/cthulhu-idol-primer.jpg", imagens);
            Assert.Contains("C:/BlueAtelier/EldritchHorrors/CthulhuIdol/gallery/cthulhu-idol-painting-progress.jpg", imagens);
            Assert.Contains("C:/BlueAtelier/EldritchHorrors/CthulhuIdol/gallery/cthulhu-idol-final.jpg", imagens);
            Assert.Equal(1, imagens.Count(caminho => caminho.EndsWith("cthulhu-idol-front.jpg", StringComparison.Ordinal)));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveListarMetadadosMesmoComCaminhoInexistente()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var modeloId = Guid.NewGuid();
            var outroModeloId = Guid.NewGuid();

            await CriarModeloComImagensAsync(opcoes, modeloId, outroModeloId);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                contexto.ImagensDoModelo.Add(new ImagemDoModelo
                {
                    ModeloId = modeloId,
                    Titulo = "Ghost image",
                    CaminhoLocal = "Z:/blue-atelier/caminho-inexistente/ghost-image.jpg",
                    Tipo = TipoImagemModelo.Referencia,
                    Ordem = 10,
                    EhPrincipal = false
                });

                await contexto.SaveChangesAsync();
            }

            var repositorio = new ImagemModeloRepositorio(new TestDbContextFactory(opcoes));
            var servico = CriarImagemModeloServico(opcoes, repositorio);

            var imagens = await servico.ListarPorModeloAsync(modeloId);

            Assert.Contains(imagens, imagem =>
                imagem.Titulo == "Ghost image"
                && imagem.CaminhoLocal == "Z:/blue-atelier/caminho-inexistente/ghost-image.jpg");
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarDetalheDaImagemPrincipalPorMainReference()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var modeloId = Guid.NewGuid();
            var outroModeloId = Guid.NewGuid();

            await CriarModeloComImagensAsync(opcoes, modeloId, outroModeloId);

            var servico = CriarImagemModeloServico(opcoes);

            var detalhe = await servico.ObterDetalheAsync(
                "eldritch-horrors",
                "cthulhu-idol",
                "main-reference");

            Assert.NotNull(detalhe);
            Assert.IsType<ImagemModeloDetalhe>(detalhe);
            Assert.IsNotType<ImagemDoModelo>(detalhe);
            Assert.Equal(modeloId, detalhe.ModeloId);
            Assert.Equal("Cthulhu Idol", detalhe.ModeloNome);
            Assert.Equal("cthulhu-idol", detalhe.ModeloSlug);
            Assert.Equal("Eldritch Horrors", detalhe.ColecaoNome);
            Assert.Equal("eldritch-horrors", detalhe.ColecaoSlug);
            Assert.Equal("Main reference", detalhe.Titulo);
            Assert.Equal("C:/BlueAtelier/EldritchHorrors/CthulhuIdol/gallery/cthulhu-idol-front.jpg", detalhe.CaminhoLocal);
            Assert.True(detalhe.EhPrincipal);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarNullParaColecaoInexistente()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await CriarModeloComImagensAsync(opcoes, Guid.NewGuid(), Guid.NewGuid());

            var servico = CriarImagemModeloServico(opcoes);

            var detalhe = await servico.ObterDetalheAsync(
                "colecao-inexistente",
                "cthulhu-idol",
                "main-reference");

            Assert.Null(detalhe);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarNullParaModeloInexistente()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await CriarModeloComImagensAsync(opcoes, Guid.NewGuid(), Guid.NewGuid());

            var servico = CriarImagemModeloServico(opcoes);

            var detalhe = await servico.ObterDetalheAsync(
                "eldritch-horrors",
                "modelo-inexistente",
                "main-reference");

            Assert.Null(detalhe);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarNullParaImagemInexistente()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await CriarModeloComImagensAsync(opcoes, Guid.NewGuid(), Guid.NewGuid());

            var servico = CriarImagemModeloServico(opcoes);

            var detalhe = await servico.ObterDetalheAsync(
                "eldritch-horrors",
                "cthulhu-idol",
                "imagem-inexistente");

            Assert.Null(detalhe);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarDetalheMesmoComCaminhoInexistente()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var caminhoInexistente = "Z:/blue-atelier/caminho-inexistente/main-reference.jpg";

            await CriarModeloComImagensAsync(opcoes, Guid.NewGuid(), Guid.NewGuid());

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                var imagemPrincipal = await contexto.ImagensDoModelo
                    .SingleAsync(imagem => imagem.Titulo == "Main reference");

                imagemPrincipal.CaminhoLocal = caminhoInexistente;
                await contexto.SaveChangesAsync();
            }

            var servico = CriarImagemModeloServico(opcoes);

            var detalhe = await servico.ObterDetalheAsync(
                "eldritch-horrors",
                "cthulhu-idol",
                "main-reference");

            Assert.NotNull(detalhe);
            Assert.Equal(caminhoInexistente, detalhe.CaminhoLocal);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    private static async Task CriarModeloComImagensAsync(
        DbContextOptions<BlueAtelierDbContext> opcoes,
        Guid modeloId,
        Guid outroModeloId)
    {
        var colecaoId = Guid.NewGuid();

        await using var contexto = new BlueAtelierDbContext(opcoes);
        await contexto.Database.MigrateAsync();
        contexto.Colecoes.Add(new Colecao
        {
            Id = colecaoId,
            Nome = "Eldritch Horrors",
            Slug = "eldritch-horrors"
        });
        contexto.Modelos.AddRange(
            new Modelo
            {
                Id = modeloId,
                ColecaoId = colecaoId,
                Nome = "Cthulhu Idol",
                Slug = "cthulhu-idol",
                EtapaAtual = EtapaModelo.Pintura,
                ProgressoPercentual = 60
            },
            new Modelo
            {
                Id = outroModeloId,
                ColecaoId = colecaoId,
                Nome = "Ruined Arch",
                Slug = "ruined-arch",
                EtapaAtual = EtapaModelo.Modelagem,
                ProgressoPercentual = 20
            });
        contexto.ImagensDoModelo.AddRange(
            new ImagemDoModelo
            {
                ModeloId = modeloId,
                Titulo = "Main reference",
                CaminhoLocal = "C:/BlueAtelier/EldritchHorrors/CthulhuIdol/gallery/cthulhu-idol-front.jpg",
                Tipo = TipoImagemModelo.Referencia,
                Ordem = 1,
                EhPrincipal = true,
                Observacao = "Referencia principal"
            },
            new ImagemDoModelo
            {
                ModeloId = modeloId,
                Titulo = "Primer test",
                CaminhoLocal = "C:/BlueAtelier/EldritchHorrors/CthulhuIdol/gallery/cthulhu-idol-primer.jpg",
                Tipo = TipoImagemModelo.Progresso,
                Ordem = 2,
                EhPrincipal = false,
                Observacao = "Primer preto"
            },
            new ImagemDoModelo
            {
                ModeloId = outroModeloId,
                Titulo = "Ruined arch front",
                CaminhoLocal = "C:/BlueAtelier/AncientRuins/RuinedArch/gallery/ruined-arch-front.jpg",
                Tipo = TipoImagemModelo.Referencia,
                Ordem = 1,
                EhPrincipal = true
            });

        await contexto.SaveChangesAsync();
    }

    private static string CriarCaminhoBancoTemporario()
    {
        return Path.Combine(Path.GetTempPath(), $"blueatelier-{Guid.NewGuid():N}.db");
    }

    private static ImagemModeloServico CriarImagemModeloServico(
        DbContextOptions<BlueAtelierDbContext> opcoes,
        ImagemModeloRepositorio? repositorio = null)
    {
        var factory = new TestDbContextFactory(opcoes);
        var imagemRepositorio = repositorio ?? new ImagemModeloRepositorio(factory);
        var modeloServico = new ModeloServico(
            new ModeloRepositorio(factory),
            new ColecaoRepositorio(factory));

        return new ImagemModeloServico(imagemRepositorio, modeloServico);
    }

    private static void RemoverBancoTemporario(string caminhoBanco)
    {
        SqliteConnection.ClearAllPools();
        GC.Collect();
        GC.WaitForPendingFinalizers();

        foreach (var caminho in new[] { caminhoBanco, $"{caminhoBanco}-wal", $"{caminhoBanco}-shm" })
        {
            if (File.Exists(caminho))
            {
                File.Delete(caminho);
            }
        }
    }

    private sealed class TestDbContextFactory(DbContextOptions<BlueAtelierDbContext> opcoes) : IDbContextFactory<BlueAtelierDbContext>
    {
        public BlueAtelierDbContext CreateDbContext()
        {
            return new BlueAtelierDbContext(opcoes);
        }
    }
}
