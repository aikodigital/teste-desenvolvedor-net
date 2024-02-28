using Application.IoC;
using Data.IoC;
using Domain.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Dependency
{
    public static class DependencyInjection
    {
        public static void InjectionService(this IServiceCollection services, IConfiguration configuration)
        {
            DomainInjection.InjectionService(services);
            ApplicationInjection.InjectionService(services);
            DataInjection.InjectionService(services);
            DataInjection.AddAutoMapperInjector(services);
        }
    }
}
