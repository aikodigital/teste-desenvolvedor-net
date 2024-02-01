using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Persistence.Context;
using Aiko.OlhoVivo.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Aiko.OlhoVivo.Presentation.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration, string connectionName)
    {

        services.AddDbContext<AikoOlhoVivoContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(connectionName)));

        return services;
    }

    public static IServiceCollection AddScoped(this IServiceCollection services)
    {

        services.AddScoped<ILineRepository, LineRepository>();
        services.AddScoped<IPositionVehicleRepository, PositionVehicleRepository>();
        services.AddScoped<IStopRepository, StopRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<ILineStopRepository, LineStopRepository>();

        return services;
    }

    public static IServiceCollection AddMediator<T>(this IServiceCollection services)
    {

        services.AddMediatR(delegate (MediatRServiceConfiguration cfg)
        {
            cfg.RegisterServicesFromAssemblies(typeof(T).GetTypeInfo().Assembly);
        });

        return services;
    }
}
