using ApiTransporte.Api.BusStops.Services;
using ApiTransporte.Api.Lines.Services;
using ApiTransporte.Api.VehiclePositions.Services;
using ApiTransporte.Api.Vehicles.Services;

namespace ApiTransporte.Core.Config
{
    public static class ServicesConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBusStopService, BusStopService>();
            services.AddScoped<ILineService, LineService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehiclePositionService, VehiclePositionService>();
            services.AddScoped<VehicleService>();
            services.AddScoped<BusStopService>();
        }
    }
}
