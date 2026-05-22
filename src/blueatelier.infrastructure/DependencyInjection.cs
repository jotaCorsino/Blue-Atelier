using BlueAtelier.Domain.Contratos;
using BlueAtelier.Infrastructure.Persistencia;
using BlueAtelier.Infrastructure.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlueAtelier.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddBlueAtelierInfrastructure(
        this IServiceCollection services,
        string caminhoBanco)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(caminhoBanco);

        services.AddDbContextFactory<BlueAtelierDbContext>(options =>
        {
            options.UseSqlite($"Data Source={caminhoBanco}");
        });

        services.AddScoped<IColecaoRepositorio, ColecaoRepositorio>();
        services.AddScoped<IBlueAtelierBancoInicializador, BlueAtelierBancoInicializador>();

        return services;
    }
}
