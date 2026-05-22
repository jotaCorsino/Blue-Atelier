using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Infrastructure.Persistencia;

public sealed class BlueAtelierBancoInicializador(
    IDbContextFactory<BlueAtelierDbContext> dbContextFactory) : IBlueAtelierBancoInicializador
{
    public async Task InicializarAsync(CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        await contexto.Database.MigrateAsync(cancellationToken);
        await BlueAtelierSeed.AplicarAsync(contexto, cancellationToken);
    }
}
