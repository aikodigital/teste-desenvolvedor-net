using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<IServiceScoped>()
                    .AddClasses(classes => classes.AssignableTo<IServiceScoped>())
                        .AsSelf()
                        .WithScopedLifetime());

            return services;
        }
    }
}