using BlueAtelier.Application.Modelos;

namespace BlueAtelier.Application.Contratos;

public interface IFavoritosServico
{
    Task<IReadOnlyList<FavoritoBarraItem>> ListarBarraAsync(
        CancellationToken cancellationToken = default);
}
