using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlueAtelier.Domain.Contratos;

public interface IRepositorio<TEntidade>
{
    Task<IReadOnlyList<TEntidade>> ListarAsync(CancellationToken cancellationToken = default);

    Task<TEntidade?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<TEntidade> SalvarAsync(TEntidade entidade, CancellationToken cancellationToken = default);

    Task RemoverAsync(Guid id, CancellationToken cancellationToken = default);
}
