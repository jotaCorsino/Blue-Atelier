using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Modelos;
using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;

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
}
