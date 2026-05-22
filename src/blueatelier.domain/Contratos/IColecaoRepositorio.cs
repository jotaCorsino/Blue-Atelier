using System.Threading;
using System.Threading.Tasks;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Domain.Contratos;

public interface IColecaoRepositorio : IRepositorio<Colecao>
{
    Task<Colecao?> ObterPorSlugAsync(string slug, CancellationToken cancellationToken = default);
}
