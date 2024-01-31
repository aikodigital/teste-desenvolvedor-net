using PublicTransportation.Application.UseCases.Lines;
using PublicTransportation.Application.UseCases.Stops;
using PublicTransportation.Application.UseCases.Vehicles;
using PublicTransportation.Domain.Interfaces.Repositories;
using PublicTransportation.Infra.Repository;

namespace PublicTransportation.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //repositories
            services.AddScoped<ILineRepository, LineRepository>();
            services.AddScoped<IStopRepository, StopRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            //services
            services.AddScoped<StopServices>();
            services.AddScoped<LineServices>();
            services.AddScoped<VehicleServices>();
        }
    }
}
