using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Modelos;
using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Domain.Enums;

namespace BlueAtelier.Application.Servicos;

public sealed class ConfiguracoesServico(
    IConfiguracoesRepositorio configuracoesRepositorio) : IConfiguracoesServico
{
    private const string IdiomaPadrao = "pt-BR";
    private const string TemaPadrao = "system";
    private const string DensidadePadrao = "comfortable";
    private const string CorDestaquePadrao = "blue";
    private const string DiretorioRaizPadrao = "C:/BlueAtelier";
    private const string DiretorioModelosPadrao = "C:/BlueAtelier/Modelos";
    private const string DiretorioBackupsPadrao = "C:/BlueAtelier/Backups";

    public async Task<ConfiguracoesGeraisResumo> ObterGeraisAsync(
        CancellationToken cancellationToken = default)
    {
        var configuracoes = await configuracoesRepositorio.ListarConfiguracoesAsync(cancellationToken);
        var configuracoesPorChave = configuracoes.ToDictionary(
            configuracao => configuracao.Chave,
            StringComparer.OrdinalIgnoreCase);

        return new ConfiguracoesGeraisResumo(
            ObterValor(configuracoesPorChave, "app.idioma", IdiomaPadrao),
            ObterValor(configuracoesPorChave, "app.tema", TemaPadrao),
            ObterValor(configuracoesPorChave, "app.densidade", DensidadePadrao),
            ObterValor(configuracoesPorChave, "app.corDestaque", CorDestaquePadrao),
            ObterValor(configuracoesPorChave, "caminhos.raiz", DiretorioRaizPadrao),
            ObterValor(configuracoesPorChave, "caminhos.modelos", DiretorioModelosPadrao),
            ObterValor(configuracoesPorChave, "caminhos.backups", DiretorioBackupsPadrao),
            ObterBooleano(configuracoesPorChave, "backup.automatico", false),
            ObterUltimaAtualizacao(configuracoes));
    }

    public async Task<IReadOnlyList<ConfiguracaoCaminhoResumo>> ListarCaminhosAsync(
        CancellationToken cancellationToken = default)
    {
        var caminhos = await configuracoesRepositorio.ListarCaminhosAsync(cancellationToken);

        return caminhos
            .Select(MapearCaminho)
            .ToList();
    }

    private static string ObterValor(
        IReadOnlyDictionary<string, ConfiguracaoApp> configuracoes,
        string chave,
        string valorPadrao)
    {
        return configuracoes.TryGetValue(chave, out var configuracao)
            && !string.IsNullOrWhiteSpace(configuracao.Valor)
            ? configuracao.Valor
            : valorPadrao;
    }

    private static bool ObterBooleano(
        IReadOnlyDictionary<string, ConfiguracaoApp> configuracoes,
        string chave,
        bool valorPadrao)
    {
        return configuracoes.TryGetValue(chave, out var configuracao)
            && bool.TryParse(configuracao.Valor, out var valor)
                ? valor
                : valorPadrao;
    }

    private static DateTimeOffset ObterUltimaAtualizacao(
        IReadOnlyList<ConfiguracaoApp> configuracoes)
    {
        return configuracoes.Count == 0
            ? DateTimeOffset.UtcNow
            : configuracoes.Max(configuracao => configuracao.AtualizadoEm);
    }

    private static ConfiguracaoCaminhoResumo MapearCaminho(CaminhoConfigurado caminho)
    {
        return new ConfiguracaoCaminhoResumo(
            caminho.Id,
            caminho.Nome,
            ObterTipoVisual(caminho.Tipo),
            caminho.Caminho,
            ObterDescricao(caminho.Tipo),
            ObterStatusVisual(caminho),
            EhObrigatorio(caminho.Tipo),
            caminho.AtualizadoEm);
    }

    private static string ObterTipoVisual(TipoCaminhoConfigurado tipo)
    {
        return tipo switch
        {
            TipoCaminhoConfigurado.PrincipalAtelier => "raiz",
            TipoCaminhoConfigurado.Colecoes => "colecoes",
            TipoCaminhoConfigurado.Modelos => "modelos",
            TipoCaminhoConfigurado.ImagensReferencias => "referencias",
            TipoCaminhoConfigurado.ArquivosVinculados => "arquivos",
            TipoCaminhoConfigurado.Exportacao => "exportacoes",
            TipoCaminhoConfigurado.Rede => "rede",
            TipoCaminhoConfigurado.Backup => "backups",
            _ => "outro"
        };
    }

    private static string ObterDescricao(TipoCaminhoConfigurado tipo)
    {
        return tipo switch
        {
            TipoCaminhoConfigurado.PrincipalAtelier => "Diretorio principal do atelier.",
            TipoCaminhoConfigurado.Colecoes => "Pasta usada para organizar colecoes.",
            TipoCaminhoConfigurado.Modelos => "Pasta principal dos modelos cadastrados.",
            TipoCaminhoConfigurado.ImagensReferencias => "Pasta reservada para imagens e referencias.",
            TipoCaminhoConfigurado.ArquivosVinculados => "Pasta reservada para arquivos vinculados.",
            TipoCaminhoConfigurado.Exportacao => "Pasta reservada para exportacoes futuras.",
            TipoCaminhoConfigurado.Rede => "Caminho de rede registrado como metadado.",
            TipoCaminhoConfigurado.Backup => "Pasta local usada como destino visual de backups.",
            _ => "Caminho configurado do atelier."
        };
    }

    private static string ObterStatusVisual(CaminhoConfigurado caminho)
    {
        if (string.IsNullOrWhiteSpace(caminho.Caminho))
        {
            return "Ausente";
        }

        return caminho.EstaAtivo ? "Conectado" : "Offline";
    }

    private static bool EhObrigatorio(TipoCaminhoConfigurado tipo)
    {
        return tipo is TipoCaminhoConfigurado.PrincipalAtelier
            or TipoCaminhoConfigurado.Modelos
            or TipoCaminhoConfigurado.Backup;
    }
}
