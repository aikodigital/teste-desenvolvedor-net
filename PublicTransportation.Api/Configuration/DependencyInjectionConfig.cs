using PublicTransportation.Domain.Interfaces.Repositories;
using PublicTransportation.Infra.Repository;
using PublicTransportation.Application.UseCases.Lines;
using PublicTransportation.Application.UseCases.Stops;

namespace PublicTransportation.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //repositories
            services.AddScoped<ILineRepository, LineRepository>();
            services.AddScoped<IStopRepository, StopRepository>();

            //services
            services.AddScoped<StopServices>();
            services.AddScoped<LineServices>();
        }
    }
}
