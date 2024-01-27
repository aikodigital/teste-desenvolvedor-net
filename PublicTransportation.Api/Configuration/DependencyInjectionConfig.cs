using PublicTransportation.Domain.Interfaces.Repositories;
using PublicTransportation.Infra.Repository;
using PublicTransportation.Application.UseCases.Lines;

namespace PublicTransportation.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //repositories
            services.AddScoped<ILineRepository, LineRepository>();

            //services
            services.AddScoped<LineServices>();
        }
    }
}
