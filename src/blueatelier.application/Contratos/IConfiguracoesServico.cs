using BlueAtelier.Application.Modelos;

namespace BlueAtelier.Application.Contratos;

public interface IConfiguracoesServico
{
    Task<ConfiguracoesGeraisResumo> ObterGeraisAsync(
        CancellationToken cancellationToken = default);
}
