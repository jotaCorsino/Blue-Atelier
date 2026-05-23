using BlueAtelier.Application.Modelos;
using BlueAtelier.Application.Servicos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;
using BlueAtelier.Infrastructure.Persistencia;
using BlueAtelier.Infrastructure.Repositorios;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Tests.Infrastructure;

public sealed class ModeloPersistenciaTests
{
    [Fact]
    public async Task Repositorio_DeveListarModelosDaColecao()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var colecaoId = Guid.NewGuid();
            var outraColecaoId = Guid.NewGuid();

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.Colecoes.AddRange(
                    new Colecao
                    {
                        Id = colecaoId,
                        Nome = "Eldritch Horrors",
                        Slug = "eldritch-horrors"
                    },
                    new Colecao
                    {
                        Id = outraColecaoId,
                        Nome = "Ancient Ruins",
                        Slug = "ancient-ruins"
                    });

                contexto.Modelos.AddRange(
                    new Modelo
                    {
                        ColecaoId = colecaoId,
                        Nome = "Cthulhu Idol",
                        Slug = "cthulhu-idol",
                        EtapaAtual = EtapaModelo.Pintura,
                        ProgressoPercentual = 60,
                        AtualizadoEm = DateTimeOffset.UtcNow
                    },
                    new Modelo
                    {
                        ColecaoId = colecaoId,
                        Nome = "Deep One Bust",
                        Slug = "deep-one-bust",
                        EtapaAtual = EtapaModelo.Impressao,
                        ProgressoPercentual = 25,
                        AtualizadoEm = DateTimeOffset.UtcNow.AddDays(-1)
                    },
                    new Modelo
                    {
                        ColecaoId = outraColecaoId,
                        Nome = "Ruined Arch",
                        Slug = "ruined-arch",
                        EtapaAtual = EtapaModelo.Modelagem,
                        ProgressoPercentual = 40,
                        AtualizadoEm = DateTimeOffset.UtcNow.AddDays(-2)
                    });

                await contexto.SaveChangesAsync();
            }

            var repositorio = new ModeloRepositorio(new TestDbContextFactory(opcoes));

            var modelos = await repositorio.ListarPorColecaoAsync(colecaoId);

            Assert.Equal(2, modelos.Count);
            Assert.All(modelos, modelo => Assert.Equal(colecaoId, modelo.ColecaoId));
            Assert.DoesNotContain(modelos, modelo => modelo.Slug == "ruined-arch");
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Repositorio_DeveListarTodosModelosPersistidos()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var colecaoId = Guid.NewGuid();

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
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
                        ColecaoId = colecaoId,
                        Nome = "Cthulhu Idol",
                        Slug = "cthulhu-idol",
                        EtapaAtual = EtapaModelo.Pintura,
                        ProgressoPercentual = 60
                    },
                    new Modelo
                    {
                        ColecaoId = colecaoId,
                        Nome = "Deep One Bust",
                        Slug = "deep-one-bust",
                        EtapaAtual = EtapaModelo.Impressao,
                        ProgressoPercentual = 25
                    });

                await contexto.SaveChangesAsync();
            }

            var repositorio = new ModeloRepositorio(new TestDbContextFactory(opcoes));

            var modelos = await repositorio.ListarAsync();

            Assert.Equal(2, modelos.Count);
            Assert.Contains(modelos, modelo => modelo.Slug == "cthulhu-idol");
            Assert.Contains(modelos, modelo => modelo.Slug == "deep-one-bust");
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarResumoDeModelosDaColecao()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var colecaoId = Guid.NewGuid();

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.Colecoes.Add(new Colecao
                {
                    Id = colecaoId,
                    Nome = "Eldritch Horrors",
                    Slug = "eldritch-horrors"
                });
                contexto.Modelos.Add(new Modelo
                {
                    ColecaoId = colecaoId,
                    Nome = "Cthulhu Idol",
                    Slug = "cthulhu-idol",
                    Descricao = "Idolo principal da colecao",
                    EtapaAtual = EtapaModelo.Pintura,
                    ProgressoPercentual = 60,
                    TipoArquivo = "STL",
                    Escala = "32mm",
                    TempoEstimado = "6h",
                    MaterialSugerido = "Resin Grey"
                });

                await contexto.SaveChangesAsync();
            }

            var repositorio = new ModeloRepositorio(new TestDbContextFactory(opcoes));
            var colecaoRepositorio = new ColecaoRepositorio(new TestDbContextFactory(opcoes));
            var servico = new ModeloServico(repositorio, colecaoRepositorio);

            var resumos = await servico.ListarPorColecaoAsync(colecaoId);

            var resumo = Assert.Single(resumos);
            Assert.Equal("Cthulhu Idol", resumo.Nome);
            Assert.Equal("cthulhu-idol", resumo.Slug);
            Assert.Equal(EtapaModelo.Pintura, resumo.EtapaAtual);
            Assert.Equal(60, resumo.ProgressoPercentual);
            Assert.Equal("Resin Grey", resumo.MaterialSugerido);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarResumoGeralDeModelos()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var colecaoId = Guid.NewGuid();

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.Colecoes.Add(new Colecao
                {
                    Id = colecaoId,
                    Nome = "Eldritch Horrors",
                    Slug = "eldritch-horrors"
                });
                contexto.Modelos.Add(new Modelo
                {
                    ColecaoId = colecaoId,
                    Nome = "Cthulhu Idol",
                    Slug = "cthulhu-idol",
                    Descricao = "Idolo principal da colecao",
                    EtapaAtual = EtapaModelo.Pintura,
                    ProgressoPercentual = 60,
                    TipoArquivo = "STL",
                    Escala = "32mm",
                    TempoEstimado = "6h",
                    MaterialSugerido = "Resin Grey"
                });

                await contexto.SaveChangesAsync();
            }

            var factory = new TestDbContextFactory(opcoes);
            var repositorio = new ModeloRepositorio(factory);
            var colecaoRepositorio = new ColecaoRepositorio(factory);
            var servico = new ModeloServico(repositorio, colecaoRepositorio);

            var resumos = await servico.ListarResumoAsync();

            var resumo = Assert.Single(resumos);
            Assert.IsType<ModeloResumo>(resumo);
            Assert.Equal("Cthulhu Idol", resumo.Nome);
            Assert.Equal("Eldritch Horrors", resumo.ColecaoNome);
            Assert.Equal("eldritch-horrors", resumo.ColecaoSlug);
            Assert.Equal(EtapaModelo.Pintura, resumo.EtapaAtual);
            Assert.Equal(60, resumo.ProgressoPercentual);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Repositorio_DeveObterModeloPorColecaoESlug()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var colecaoId = Guid.NewGuid();

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.Colecoes.Add(new Colecao
                {
                    Id = colecaoId,
                    Nome = "Eldritch Horrors",
                    Slug = "eldritch-horrors"
                });
                contexto.Modelos.Add(new Modelo
                {
                    ColecaoId = colecaoId,
                    Nome = "Cthulhu Idol",
                    Slug = "cthulhu-idol",
                    EtapaAtual = EtapaModelo.Pintura,
                    ProgressoPercentual = 60
                });

                await contexto.SaveChangesAsync();
            }

            var repositorio = new ModeloRepositorio(new TestDbContextFactory(opcoes));

            var modelo = await repositorio.ObterPorColecaoESlugAsync(colecaoId, "cthulhu-idol");

            Assert.NotNull(modelo);
            Assert.Equal("Cthulhu Idol", modelo.Nome);
            Assert.Equal(colecaoId, modelo.ColecaoId);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Repositorio_NaoDeveRetornarModeloDeOutraColecaoPorSlug()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var colecaoId = Guid.NewGuid();
            var outraColecaoId = Guid.NewGuid();

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.Colecoes.AddRange(
                    new Colecao
                    {
                        Id = colecaoId,
                        Nome = "Eldritch Horrors",
                        Slug = "eldritch-horrors"
                    },
                    new Colecao
                    {
                        Id = outraColecaoId,
                        Nome = "Ancient Ruins",
                        Slug = "ancient-ruins"
                    });

                contexto.Modelos.Add(new Modelo
                {
                    ColecaoId = outraColecaoId,
                    Nome = "Cthulhu Idol",
                    Slug = "cthulhu-idol",
                    EtapaAtual = EtapaModelo.Modelagem,
                    ProgressoPercentual = 30
                });

                await contexto.SaveChangesAsync();
            }

            var repositorio = new ModeloRepositorio(new TestDbContextFactory(opcoes));

            var modelo = await repositorio.ObterPorColecaoESlugAsync(colecaoId, "cthulhu-idol");

            Assert.Null(modelo);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarDetalheDeModeloPorSlug()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var colecaoId = Guid.NewGuid();

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.Colecoes.Add(new Colecao
                {
                    Id = colecaoId,
                    Nome = "Eldritch Horrors",
                    Slug = "eldritch-horrors"
                });
                contexto.Modelos.Add(new Modelo
                {
                    ColecaoId = colecaoId,
                    Nome = "Cthulhu Idol",
                    Slug = "cthulhu-idol",
                    Descricao = "Idolo principal da colecao",
                    EtapaAtual = EtapaModelo.Pintura,
                    ProgressoPercentual = 60,
                    TipoArquivo = "STL",
                    Escala = "32mm",
                    TempoEstimado = "6h",
                    MaterialSugerido = "Resin Grey",
                    Observacoes = "Pintura em andamento"
                });

                await contexto.SaveChangesAsync();
            }

            var factory = new TestDbContextFactory(opcoes);
            var repositorio = new ModeloRepositorio(factory);
            var colecaoRepositorio = new ColecaoRepositorio(factory);
            var servico = new ModeloServico(repositorio, colecaoRepositorio);

            var detalhe = await servico.ObterDetalhePorSlugAsync("eldritch-horrors", "cthulhu-idol");

            Assert.NotNull(detalhe);
            Assert.IsType<ModeloDetalhe>(detalhe);
            Assert.Equal("Cthulhu Idol", detalhe.Nome);
            Assert.Equal("Eldritch Horrors", detalhe.ColecaoNome);
            Assert.Equal("eldritch-horrors", detalhe.ColecaoSlug);
            Assert.Equal("cthulhu-idol", detalhe.Slug);
            Assert.Equal(EtapaModelo.Pintura, detalhe.EtapaAtual);
            Assert.Equal("Resin Grey", detalhe.MaterialSugerido);
            Assert.Equal("Pintura em andamento", detalhe.Observacoes);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarNullParaColecaoInexistenteNoDetalhe()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var factory = new TestDbContextFactory(opcoes);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
            }

            var repositorio = new ModeloRepositorio(factory);
            var colecaoRepositorio = new ColecaoRepositorio(factory);
            var servico = new ModeloServico(repositorio, colecaoRepositorio);

            var detalhe = await servico.ObterDetalhePorSlugAsync("nao-existe", "cthulhu-idol");

            Assert.Null(detalhe);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Servico_DeveRetornarNullParaModeloInexistenteNoDetalhe()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);
            var colecaoId = Guid.NewGuid();

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                contexto.Colecoes.Add(new Colecao
                {
                    Id = colecaoId,
                    Nome = "Eldritch Horrors",
                    Slug = "eldritch-horrors"
                });

                await contexto.SaveChangesAsync();
            }

            var factory = new TestDbContextFactory(opcoes);
            var repositorio = new ModeloRepositorio(factory);
            var colecaoRepositorio = new ColecaoRepositorio(factory);
            var servico = new ModeloServico(repositorio, colecaoRepositorio);

            var detalhe = await servico.ObterDetalhePorSlugAsync("eldritch-horrors", "nao-existe");

            Assert.Null(detalhe);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Seed_DeveCriarModelosDeEldritchHorrorsSemDuplicar()
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
            var colecao = await consulta.Colecoes.SingleAsync(item => item.Slug == "eldritch-horrors");
            var modelos = await consulta.Modelos
                .Where(modelo => modelo.ColecaoId == colecao.Id)
                .Select(modelo => modelo.Slug)
                .ToListAsync();

            Assert.Equal(6, modelos.Count);
            Assert.Contains("cthulhu-idol", modelos);
            Assert.Contains("deep-one-bust", modelos);
            Assert.Contains("tentacle-beast", modelos);
            Assert.Contains("ancient-cultist", modelos);
            Assert.Contains("forgotten-horror", modelos);
            Assert.Contains("abyssal-statue", modelos);
            Assert.Equal(1, modelos.Count(slug => slug == "cthulhu-idol"));
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
    }

    [Fact]
    public async Task Seed_DeveAparecerNaListagemGeralDeModelos()
    {
        var caminhoBanco = CriarCaminhoBancoTemporario();

        try
        {
            var opcoes = BlueAtelierDbContextFactory.CriarOpcoesSqlite(caminhoBanco);

            await using (var contexto = new BlueAtelierDbContext(opcoes))
            {
                await contexto.Database.MigrateAsync();
                await BlueAtelierSeed.AplicarAsync(contexto);
            }

            var factory = new TestDbContextFactory(opcoes);
            var repositorio = new ModeloRepositorio(factory);
            var colecaoRepositorio = new ColecaoRepositorio(factory);
            var servico = new ModeloServico(repositorio, colecaoRepositorio);

            var resumos = await servico.ListarResumoAsync();
            var slugs = resumos.Select(modelo => modelo.Slug).ToList();

            Assert.Equal(6, resumos.Count(modelo => modelo.ColecaoSlug == "eldritch-horrors"));
            Assert.Contains("cthulhu-idol", slugs);
            Assert.Contains("deep-one-bust", slugs);
            Assert.Contains("tentacle-beast", slugs);
            Assert.Contains("ancient-cultist", slugs);
            Assert.Contains("forgotten-horror", slugs);
            Assert.Contains("abyssal-statue", slugs);
        }
        finally
        {
            RemoverBancoTemporario(caminhoBanco);
        }
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
