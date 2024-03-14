using PublicTransport.API.Repositories.Interface;
using PublicTransport.API.Repositories;

namespace PublicTransport.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<ILineRepository, LineRepository>();
        services.AddScoped<IStopRepository, StopRepository>();
        services.AddScoped<ILineStopRepository, LineStopRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IVehiclePositionRepository, VehiclePositionRepository>();

        return services;
    }
}
