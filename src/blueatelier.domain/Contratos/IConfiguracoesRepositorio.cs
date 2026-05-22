using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Domain.Contratos;

public interface IConfiguracoesRepositorio
{
    Task<IReadOnlyList<ConfiguracaoApp>> ListarConfiguracoesAsync(CancellationToken cancellationToken = default);

    Task<ConfiguracaoApp?> ObterConfiguracaoAsync(string chave, CancellationToken cancellationToken = default);

    Task<ConfiguracaoApp> SalvarConfiguracaoAsync(ConfiguracaoApp configuracao, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<CaminhoConfigurado>> ListarCaminhosAsync(CancellationToken cancellationToken = default);

    Task<CaminhoConfigurado> SalvarCaminhoAsync(CaminhoConfigurado caminho, CancellationToken cancellationToken = default);

    Task<ModeloPastas?> ObterModeloPastasAsync(CancellationToken cancellationToken = default);

    Task<ModeloPastas> SalvarModeloPastasAsync(ModeloPastas modeloPastas, CancellationToken cancellationToken = default);
}
