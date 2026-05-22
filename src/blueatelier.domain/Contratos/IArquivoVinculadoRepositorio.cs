using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Domain.Contratos;

public interface IArquivoVinculadoRepositorio : IRepositorio<ArquivoVinculado>
{
    Task<IReadOnlyList<ArquivoVinculado>> ListarPorModeloAsync(Guid modeloId, CancellationToken cancellationToken = default);
}
