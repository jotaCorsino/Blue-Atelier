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
            var servico = new ImagemModeloServico(repositorio);

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
            var servico = new ImagemModeloServico(repositorio);

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
