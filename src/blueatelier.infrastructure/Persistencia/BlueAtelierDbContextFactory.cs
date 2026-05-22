using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlueAtelier.Infrastructure.Persistencia;

public sealed class BlueAtelierDbContextFactory : IDesignTimeDbContextFactory<BlueAtelierDbContext>
{
    public static BlueAtelierDbContext CriarComSqlite(string caminhoBanco)
    {
        return new BlueAtelierDbContext(CriarOpcoesSqlite(caminhoBanco));
    }

    public static DbContextOptions<BlueAtelierDbContext> CriarOpcoesSqlite(string caminhoBanco)
    {
        var connectionString = $"Data Source={caminhoBanco}";

        return new DbContextOptionsBuilder<BlueAtelierDbContext>()
            .UseSqlite(connectionString)
            .Options;
    }

    public BlueAtelierDbContext CreateDbContext(string[] args)
    {
        var caminhoBanco = args.FirstOrDefault();

        if (string.IsNullOrWhiteSpace(caminhoBanco))
        {
            caminhoBanco = Path.Combine(Environment.CurrentDirectory, "blueatelier.design.db");
        }

        return CriarComSqlite(caminhoBanco);
    }
}
