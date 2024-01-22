using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportePublico.Infra.Contexts;

namespace TransportePublico.Infra.DI;

public static class DatabaseDI
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration _configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(_configuration.GetConnectionString("DATABASE_URL") ?? throw new InvalidOperationException())
                   .ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning)));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        MapAutomaticallyRepositories(services);
        return services;
    }

    private static void MapAutomaticallyRepositories(IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name!.Contains("TransportePublico"));
        var implementacoes = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Any(y => y.Name.Contains("Repository")));
        foreach (var implementacao in implementacoes)
        {
            foreach (var interfaceType in implementacao.GetInterfaces())
            {
                services.AddScoped(interfaceType, implementacao);
            }
        }
    }
}