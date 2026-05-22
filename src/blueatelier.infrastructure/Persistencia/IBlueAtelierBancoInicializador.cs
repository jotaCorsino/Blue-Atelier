namespace BlueAtelier.Infrastructure.Persistencia;

public interface IBlueAtelierBancoInicializador
{
    Task InicializarAsync(CancellationToken cancellationToken = default);
}
