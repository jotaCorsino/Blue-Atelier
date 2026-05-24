using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Domain.Contratos;

public interface IImagemModeloRepositorio : IRepositorio<ImagemDoModelo>
{
    Task<IReadOnlyList<ImagemDoModelo>> ListarPorModeloAsync(Guid modeloId, CancellationToken cancellationToken = default);

    Task<ImagemDoModelo?> ObterPrincipalPorModeloAsync(Guid modeloId, CancellationToken cancellationToken = default);
}
