using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Domain.Contratos;

public interface IModeloRepositorio : IRepositorio<Modelo>
{
    Task<IReadOnlyList<Modelo>> ListarPorColecaoAsync(Guid colecaoId, CancellationToken cancellationToken = default);
}
