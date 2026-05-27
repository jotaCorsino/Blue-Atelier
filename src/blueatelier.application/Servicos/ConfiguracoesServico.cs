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
    private const string DescricaoModeloPastasPadrao = "Estrutura base para organizar arquivos de modelos, imagens, referencias e exportacoes.";

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

    public async Task<ConfiguracoesAparenciaResumo> ObterAparenciaAsync(
        CancellationToken cancellationToken = default)
    {
        var configuracoes = await configuracoesRepositorio.ListarConfiguracoesAsync(cancellationToken);
        var configuracoesPorChave = configuracoes.ToDictionary(
            configuracao => configuracao.Chave,
            StringComparer.OrdinalIgnoreCase);

        return new ConfiguracoesAparenciaResumo(
            ObterValor(configuracoesPorChave, "app.tema", TemaPadrao),
            ObterValor(configuracoesPorChave, "app.densidade", DensidadePadrao),
            ObterValor(configuracoesPorChave, "app.corDestaque", CorDestaquePadrao),
            ObterUltimaAtualizacao(configuracoes));
    }

    public async Task<ModeloPastasResumo?> ObterModeloPastasAsync(
        CancellationToken cancellationToken = default)
    {
        var modeloPastas = await configuracoesRepositorio.ObterModeloPastasAsync(cancellationToken);

        return modeloPastas is null
            ? null
            : new ModeloPastasResumo(
                modeloPastas.Id,
                modeloPastas.Nome,
                DescricaoModeloPastasPadrao,
                modeloPastas.Estrutura,
                MapearItensModeloPastas(modeloPastas.Estrutura),
                modeloPastas.AtualizadoEm);
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

    private static IReadOnlyList<ModeloPastasItemResumo> MapearItensModeloPastas(string estrutura)
    {
        return estrutura
            .Replace("\r\n", "\n", StringComparison.Ordinal)
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select((linha, indice) => MapearItemModeloPastas(linha, indice))
            .Where(item => !string.IsNullOrWhiteSpace(item.Nome))
            .ToList();
    }

    private static ModeloPastasItemResumo MapearItemModeloPastas(string linha, int indice)
    {
        var caminhoRelativo = linha.Trim().TrimStart('/').Replace('\\', '/');
        var partes = caminhoRelativo.Split(["/"], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var nome = partes.Length == 0 ? string.Empty : partes[^1];
        var nivel = Math.Max(0, partes.Length - 1);

        return new ModeloPastasItemResumo(
            nome,
            caminhoRelativo.EndsWith("/", StringComparison.Ordinal) ? caminhoRelativo : $"{caminhoRelativo}/",
            nivel,
            nivel == 0 ? "raiz" : "pasta",
            indice,
            nivel == 0);
    }
}
