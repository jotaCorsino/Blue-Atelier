using BlueAtelier.Application.Contratos;
using BlueAtelier.Application.Servicos;
using BlueAtelier.Infrastructure;
using BlueAtelier.Infrastructure.Persistencia;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlueAtelier.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddScoped<IColecaoServico, ColecaoServico>();
        builder.Services.AddScoped<IModeloServico, ModeloServico>();
        builder.Services.AddScoped<IArquivoVinculadoServico, ArquivoVinculadoServico>();

        var caminhoBanco = Path.Combine(FileSystem.AppDataDirectory, "blueatelier.db");
        builder.Services.AddBlueAtelierInfrastructure(caminhoBanco);

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        InicializarBanco(app);

        return app;
    }

    private static void InicializarBanco(MauiApp app)
    {
        using var scope = app.Services.CreateScope();
        var inicializador = scope.ServiceProvider.GetRequiredService<IBlueAtelierBancoInicializador>();

        inicializador.InicializarAsync().GetAwaiter().GetResult();
    }
}
