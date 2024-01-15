using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TransportePublico.Domain.Entity.Linhas;
using TransportePublico.Domain.Entity.Paradas;
using TransportePublico.Domain.Entity.PosicoesVeiculos;
using TransportePublico.Domain.Entity.Veiculos;
using TransportePublico.Infra.Repositories.Linhas;
using TransportePublico.Infra.Repositories.Paradas;
using TransportePublico.Infra.Repositories.PosicoesVeiculos;
using TransportePublico.Infra.Repositories.Veiculos;

namespace TransportePublico.Infra;

public static class DependencyInjection
{

    public static IServiceCollection AddLibs(this IServiceCollection services)
    {
        // Adicionando AutoMapper - veja mais em https://docs.automapper.org/en/stable/Getting-started.html
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // Adicionando MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        services.AddScoped<ILinhaRepository, LinhaRepository>();
        services.AddScoped<IParadaRepository, ParadaRepository>();
        services.AddScoped<IPosicaoVeiculoRepository, PosicaoVeiculoRepository>();
        services.AddScoped<IVeiculoRepository, VeiculoRepository>();
        return services;
    }
}