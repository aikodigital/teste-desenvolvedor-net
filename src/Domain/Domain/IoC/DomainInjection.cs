using Domain.Services;
using Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.IoC
{
    public static class DomainInjection
    {
        public static void InjectionService(this IServiceCollection services)
        {
            services.AddScoped<IStopServices, StopServices>();
            services.AddScoped<ILineServices, LineServices>();
            services.AddScoped<IVehicleServices, VehicleServices>();
            services.AddScoped<IVehiclePositionServices, VehiclePositionServices>();
        }
    }
}
