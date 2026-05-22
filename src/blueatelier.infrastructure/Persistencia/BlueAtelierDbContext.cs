using BlueAtelier.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Infrastructure.Persistencia;

public sealed class BlueAtelierDbContext : DbContext
{
    public BlueAtelierDbContext(DbContextOptions<BlueAtelierDbContext> options)
        : base(options)
    {
    }

    public DbSet<Colecao> Colecoes => Set<Colecao>();

    public DbSet<Modelo> Modelos => Set<Modelo>();

    public DbSet<ImagemDoModelo> ImagensDoModelo => Set<ImagemDoModelo>();

    public DbSet<ArquivoVinculado> ArquivosVinculados => Set<ArquivoVinculado>();

    public DbSet<LinkFavorito> LinksFavoritos => Set<LinkFavorito>();

    public DbSet<PastaFavoritos> PastasFavoritos => Set<PastaFavoritos>();

    public DbSet<ConfiguracaoApp> ConfiguracoesApp => Set<ConfiguracaoApp>();

    public DbSet<CaminhoConfigurado> CaminhosConfigurados => Set<CaminhoConfigurado>();

    public DbSet<ModeloPastas> ModelosPastas => Set<ModeloPastas>();

    public DbSet<RegistroBackup> RegistrosBackup => Set<RegistroBackup>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        MapearColecao(modelBuilder);
        MapearModelo(modelBuilder);
        MapearImagemDoModelo(modelBuilder);
        MapearArquivoVinculado(modelBuilder);
        MapearPastaFavoritos(modelBuilder);
        MapearLinkFavorito(modelBuilder);
        MapearConfiguracaoApp(modelBuilder);
        MapearCaminhoConfigurado(modelBuilder);
        MapearModeloPastas(modelBuilder);
        MapearRegistroBackup(modelBuilder);
    }

    private static void MapearColecao(ModelBuilder modelBuilder)
    {
        var entidade = modelBuilder.Entity<Colecao>();

        entidade.ToTable("Colecoes");
        entidade.HasKey(colecao => colecao.Id);
        entidade.Property(colecao => colecao.Nome).IsRequired().HasMaxLength(200);
        entidade.Property(colecao => colecao.Slug).IsRequired().HasMaxLength(220);
        entidade.Property(colecao => colecao.Descricao).HasMaxLength(1000);
        entidade.Property(colecao => colecao.ImagemCapa).HasMaxLength(512);
        entidade.HasIndex(colecao => colecao.Slug).IsUnique();
        entidade.HasIndex(colecao => colecao.Nome);
    }

    private static void MapearModelo(ModelBuilder modelBuilder)
    {
        var entidade = modelBuilder.Entity<Modelo>();

        entidade.ToTable("Modelos");
        entidade.HasKey(modelo => modelo.Id);
        entidade.Property(modelo => modelo.Nome).IsRequired().HasMaxLength(200);
        entidade.Property(modelo => modelo.Slug).IsRequired().HasMaxLength(220);
        entidade.Property(modelo => modelo.Descricao).HasMaxLength(1000);
        entidade.Property(modelo => modelo.EtapaAtual).HasConversion<string>().HasMaxLength(64);
        entidade.Property(modelo => modelo.TipoArquivo).HasMaxLength(64);
        entidade.Property(modelo => modelo.Escala).HasMaxLength(64);
        entidade.Property(modelo => modelo.TempoEstimado).HasMaxLength(128);
        entidade.Property(modelo => modelo.MaterialSugerido).HasMaxLength(200);
        entidade.Property(modelo => modelo.Observacoes).HasMaxLength(2000);
        entidade.HasIndex(modelo => new { modelo.ColecaoId, modelo.Slug }).IsUnique();
        entidade.HasIndex(modelo => modelo.Nome);
        entidade
            .HasOne<Colecao>()
            .WithMany()
            .HasForeignKey(modelo => modelo.ColecaoId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void MapearImagemDoModelo(ModelBuilder modelBuilder)
    {
        var entidade = modelBuilder.Entity<ImagemDoModelo>();

        entidade.ToTable("ImagensDoModelo");
        entidade.HasKey(imagem => imagem.Id);
        entidade.Property(imagem => imagem.Titulo).IsRequired().HasMaxLength(200);
        entidade.Property(imagem => imagem.CaminhoLocal).IsRequired().HasMaxLength(1024);
        entidade.Property(imagem => imagem.Tipo).HasConversion<string>().HasMaxLength(64);
        entidade.Property(imagem => imagem.Observacao).HasMaxLength(1000);
        entidade.HasIndex(imagem => new { imagem.ModeloId, imagem.Ordem });
        entidade
            .HasOne<Modelo>()
            .WithMany()
            .HasForeignKey(imagem => imagem.ModeloId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void MapearArquivoVinculado(ModelBuilder modelBuilder)
    {
        var entidade = modelBuilder.Entity<ArquivoVinculado>();

        entidade.ToTable("ArquivosVinculados");
        entidade.HasKey(arquivo => arquivo.Id);
        entidade.Property(arquivo => arquivo.Nome).IsRequired().HasMaxLength(260);
        entidade.Property(arquivo => arquivo.CaminhoLocal).IsRequired().HasMaxLength(1024);
        entidade.Property(arquivo => arquivo.Tipo).HasConversion<string>().HasMaxLength(64);
        entidade.Property(arquivo => arquivo.Extensao).HasMaxLength(32);
        entidade.HasIndex(arquivo => new { arquivo.ModeloId, arquivo.Nome });
        entidade
            .HasOne<Modelo>()
            .WithMany()
            .HasForeignKey(arquivo => arquivo.ModeloId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void MapearPastaFavoritos(ModelBuilder modelBuilder)
    {
        var entidade = modelBuilder.Entity<PastaFavoritos>();

        entidade.ToTable("PastasFavoritos");
        entidade.HasKey(pasta => pasta.Id);
        entidade.Property(pasta => pasta.Nome).IsRequired().HasMaxLength(160);
        entidade.Property(pasta => pasta.TomVisual).HasMaxLength(80);
        entidade.HasIndex(pasta => pasta.Ordem);
        entidade.HasIndex(pasta => pasta.Nome);
    }

    private static void MapearLinkFavorito(ModelBuilder modelBuilder)
    {
        var entidade = modelBuilder.Entity<LinkFavorito>();

        entidade.ToTable("LinksFavoritos");
        entidade.HasKey(link => link.Id);
        entidade.Property(link => link.Nome).IsRequired().HasMaxLength(200);
        entidade.Property(link => link.Url).IsRequired().HasMaxLength(1000);
        entidade.Property(link => link.Iniciais).HasMaxLength(8);
        entidade.Property(link => link.TomVisual).HasMaxLength(80);
        entidade.HasIndex(link => new { link.PastaFavoritosId, link.Ordem });
        entidade.HasIndex(link => link.Nome);
        entidade
            .HasOne<PastaFavoritos>()
            .WithMany()
            .HasForeignKey(link => link.PastaFavoritosId)
            .OnDelete(DeleteBehavior.SetNull);
    }

    private static void MapearConfiguracaoApp(ModelBuilder modelBuilder)
    {
        var entidade = modelBuilder.Entity<ConfiguracaoApp>();

        entidade.ToTable("ConfiguracoesApp");
        entidade.HasKey(configuracao => configuracao.Id);
        entidade.Property(configuracao => configuracao.Chave).IsRequired().HasMaxLength(128);
        entidade.Property(configuracao => configuracao.Valor).IsRequired().HasMaxLength(2000);
        entidade.HasIndex(configuracao => configuracao.Chave).IsUnique();
    }

    private static void MapearCaminhoConfigurado(ModelBuilder modelBuilder)
    {
        var entidade = modelBuilder.Entity<CaminhoConfigurado>();

        entidade.ToTable("CaminhosConfigurados");
        entidade.HasKey(caminho => caminho.Id);
        entidade.Property(caminho => caminho.Nome).IsRequired().HasMaxLength(160);
        entidade.Property(caminho => caminho.Caminho).IsRequired().HasMaxLength(1024);
        entidade.Property(caminho => caminho.Tipo).HasConversion<string>().HasMaxLength(64);
        entidade.HasIndex(caminho => caminho.Nome);
        entidade.HasIndex(caminho => caminho.Tipo);
    }

    private static void MapearModeloPastas(ModelBuilder modelBuilder)
    {
        var entidade = modelBuilder.Entity<ModeloPastas>();

        entidade.ToTable("ModelosPastas");
        entidade.HasKey(modeloPastas => modeloPastas.Id);
        entidade.Property(modeloPastas => modeloPastas.Nome).IsRequired().HasMaxLength(160);
        entidade.Property(modeloPastas => modeloPastas.Estrutura).IsRequired().HasMaxLength(4000);
        entidade.HasIndex(modeloPastas => modeloPastas.Nome);
    }

    private static void MapearRegistroBackup(ModelBuilder modelBuilder)
    {
        var entidade = modelBuilder.Entity<RegistroBackup>();

        entidade.ToTable("RegistrosBackup");
        entidade.HasKey(registro => registro.Id);
        entidade.Property(registro => registro.Caminho).IsRequired().HasMaxLength(1024);
        entidade.Property(registro => registro.Status).HasConversion<string>().HasMaxLength(64);
        entidade.HasIndex(registro => registro.CriadoEm);
        entidade.HasIndex(registro => registro.Status);
    }
}
