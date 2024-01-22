using ApiTransporte.Core.Repositories.BusStops;
using ApiTransporte.Core.Repositories.Lines;
using ApiTransporte.Core.Repositories.VehiclePositions;
using ApiTransporte.Core.Repositories.Vehicles;

namespace ApiTransporte.Core.Config
{
    public static class RepositoriesConfig
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBusStopRepository, BusStopRepository>();
            services.AddScoped<ILineRepository, LineRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehiclePositionRepository, VehiclePositionRepository>();
        }
    }
}
