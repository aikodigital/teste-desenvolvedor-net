using Application.Commands;
using Application.Commands.Contracts;
using Application.Queries;
using Application.Queries.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC
{
    public static class ApplicationInjection
    {
        public static void InjectionService(this IServiceCollection services)
        {
            services.AddScoped<IStopQueryServiceApplication, StopQueryServiceApplication>();
            services.AddScoped<IStopCommandServiceApplication, StopCommandServiceApplication>();

            services.AddScoped<ILineQueryServiceApplication, LineQueryServiceApplication>();
            services.AddScoped<ILineCommandServiceApplication, LineCommandServiceApplication>();

            services.AddScoped<IVehicleQueryServiceApplication, VehicleQueryServiceApplication>();
            services.AddScoped<IVehicleCommandServiceApplication, VehicleCommandServiceApplication>();

            services.AddScoped<IVehiclePositionQueryServiceApplication, VehiclePositionQueryServiceApplication>();
            services.AddScoped<IVehiclePositionCommandServiceApplication, VehiclePositionCommandServiceApplication>();
        }
    }
}
