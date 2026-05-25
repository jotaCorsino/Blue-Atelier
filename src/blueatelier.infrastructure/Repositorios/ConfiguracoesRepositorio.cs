using BlueAtelier.Domain.Contratos;
using BlueAtelier.Domain.Entidades;
using BlueAtelier.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace BlueAtelier.Infrastructure.Repositorios;

public sealed class ConfiguracoesRepositorio(
    IDbContextFactory<BlueAtelierDbContext> dbContextFactory) : IConfiguracoesRepositorio
{
    public async Task<IReadOnlyList<ConfiguracaoApp>> ListarConfiguracoesAsync(
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.ConfiguracoesApp
            .AsNoTracking()
            .OrderBy(configuracao => configuracao.Chave)
            .ToListAsync(cancellationToken);
    }

    public async Task<ConfiguracaoApp?> ObterConfiguracaoAsync(
        string chave,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.ConfiguracoesApp
            .AsNoTracking()
            .SingleOrDefaultAsync(configuracao => configuracao.Chave == chave, cancellationToken);
    }

    public async Task<ConfiguracaoApp> SalvarConfiguracaoAsync(
        ConfiguracaoApp configuracao,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.ConfiguracoesApp
            .SingleOrDefaultAsync(
                item => item.Id == configuracao.Id || item.Chave == configuracao.Chave,
                cancellationToken);

        if (existente is null)
        {
            contexto.ConfiguracoesApp.Add(configuracao);
            await contexto.SaveChangesAsync(cancellationToken);

            return configuracao;
        }

        existente.Chave = configuracao.Chave;
        existente.Valor = configuracao.Valor;
        existente.AtualizadoEm = configuracao.AtualizadoEm;

        await contexto.SaveChangesAsync(cancellationToken);

        return existente;
    }

    public async Task<IReadOnlyList<CaminhoConfigurado>> ListarCaminhosAsync(
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.CaminhosConfigurados
            .AsNoTracking()
            .OrderBy(caminho => caminho.Tipo)
            .ThenBy(caminho => caminho.Nome)
            .ToListAsync(cancellationToken);
    }

    public async Task<CaminhoConfigurado> SalvarCaminhoAsync(
        CaminhoConfigurado caminho,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.CaminhosConfigurados
            .SingleOrDefaultAsync(item => item.Id == caminho.Id, cancellationToken);

        if (existente is null)
        {
            contexto.CaminhosConfigurados.Add(caminho);
        }
        else
        {
            contexto.Entry(existente).CurrentValues.SetValues(caminho);
        }

        await contexto.SaveChangesAsync(cancellationToken);

        return caminho;
    }

    public async Task<ModeloPastas?> ObterModeloPastasAsync(
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        return await contexto.ModelosPastas
            .AsNoTracking()
            .OrderByDescending(modeloPastas => modeloPastas.AtualizadoEm)
            .ThenBy(modeloPastas => modeloPastas.Nome)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ModeloPastas> SalvarModeloPastasAsync(
        ModeloPastas modeloPastas,
        CancellationToken cancellationToken = default)
    {
        await using var contexto = dbContextFactory.CreateDbContext();

        var existente = await contexto.ModelosPastas
            .SingleOrDefaultAsync(item => item.Id == modeloPastas.Id, cancellationToken);

        if (existente is null)
        {
            contexto.ModelosPastas.Add(modeloPastas);
        }
        else
        {
            contexto.Entry(existente).CurrentValues.SetValues(modeloPastas);
        }

        await contexto.SaveChangesAsync(cancellationToken);

        return modeloPastas;
    }
}
