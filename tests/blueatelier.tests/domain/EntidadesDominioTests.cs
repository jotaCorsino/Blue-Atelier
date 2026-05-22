using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Tests.Domain;

public sealed class EntidadesDominioTests
{
    [Fact]
    public void Colecao_DeveSerCriadaComIdentificadorEValoresBasicos()
    {
        var colecao = new Colecao
        {
            Nome = "Eldritch Horrors",
            Slug = "eldritch-horrors",
            Descricao = "Colecao de miniaturas sombrias"
        };

        Assert.NotEqual(Guid.Empty, colecao.Id);
        Assert.Equal("Eldritch Horrors", colecao.Nome);
        Assert.Equal("eldritch-horrors", colecao.Slug);
        Assert.False(colecao.EstaArquivada);
    }

    [Fact]
    public void Modelo_DeveManterVinculoLogicoComColecao()
    {
        var colecaoId = Guid.NewGuid();

        var modelo = new Modelo
        {
            ColecaoId = colecaoId,
            Nome = "Cthulhu Idol",
            Slug = "cthulhu-idol",
            EtapaAtual = EtapaModelo.Pintura,
            ProgressoPercentual = 72
        };

        Assert.NotEqual(Guid.Empty, modelo.Id);
        Assert.Equal(colecaoId, modelo.ColecaoId);
        Assert.Equal(EtapaModelo.Pintura, modelo.EtapaAtual);
        Assert.Equal(72, modelo.ProgressoPercentual);
    }

    [Fact]
    public void LinkFavorito_DevePermitirPastaOpcional()
    {
        var pastaId = Guid.NewGuid();

        var link = new LinkFavorito
        {
            PastaFavoritosId = pastaId,
            Nome = "ArtStation",
            Url = "https://www.artstation.com",
            Iniciais = "AS",
            Ordem = 2
        };

        Assert.NotEqual(Guid.Empty, link.Id);
        Assert.Equal(pastaId, link.PastaFavoritosId);
        Assert.Equal("ArtStation", link.Nome);
        Assert.Equal(2, link.Ordem);
    }

    [Fact]
    public void CaminhoConfigurado_DeveGuardarTipoEStatusAtivo()
    {
        var caminho = new CaminhoConfigurado
        {
            Nome = "Colecoes",
            Caminho = @"D:\Blue Atelier\Colecoes",
            Tipo = TipoCaminhoConfigurado.Colecoes,
            EstaAtivo = true
        };

        Assert.NotEqual(Guid.Empty, caminho.Id);
        Assert.Equal(TipoCaminhoConfigurado.Colecoes, caminho.Tipo);
        Assert.True(caminho.EstaAtivo);
    }

    [Fact]
    public void ArquivoVinculado_DevePermitirTamanhoOpcional()
    {
        var modeloId = Guid.NewGuid();

        var arquivo = new ArquivoVinculado
        {
            ModeloId = modeloId,
            Nome = "cthulhu-idol.stl",
            CaminhoLocal = @"D:\Blue Atelier\Modelos\cthulhu-idol.stl",
            Tipo = TipoArquivoVinculado.Modelo3D,
            Extensao = ".stl"
        };

        Assert.NotEqual(Guid.Empty, arquivo.Id);
        Assert.Equal(modeloId, arquivo.ModeloId);
        Assert.Equal(TipoArquivoVinculado.Modelo3D, arquivo.Tipo);
        Assert.Null(arquivo.TamanhoBytes);
    }
}
