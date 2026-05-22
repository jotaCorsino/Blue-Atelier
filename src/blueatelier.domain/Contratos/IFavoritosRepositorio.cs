using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlueAtelier.Domain.Entidades;

namespace BlueAtelier.Domain.Contratos;

public interface IFavoritosRepositorio
{
    Task<IReadOnlyList<LinkFavorito>> ListarLinksAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<PastaFavoritos>> ListarPastasAsync(CancellationToken cancellationToken = default);

    Task<LinkFavorito?> ObterLinkPorIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PastaFavoritos?> ObterPastaPorIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<LinkFavorito> SalvarLinkAsync(LinkFavorito link, CancellationToken cancellationToken = default);

    Task<PastaFavoritos> SalvarPastaAsync(PastaFavoritos pasta, CancellationToken cancellationToken = default);

    Task RemoverLinkAsync(Guid id, CancellationToken cancellationToken = default);

    Task RemoverPastaAsync(Guid id, CancellationToken cancellationToken = default);
}
