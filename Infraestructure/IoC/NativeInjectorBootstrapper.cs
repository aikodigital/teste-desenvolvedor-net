using Application.Repositories;
using Application.Services;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILinhaRepository, LinhaRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IParadaRepository, ParadaRepository>();
            services.AddScoped<IPosicaoVeiculoRepository, PosicaoVeiculoRepository>();
            services.AddScoped<ILinhaParadaRepository, LinhaParadaRepository>();
            services.AddScoped<IVeiculoLinhaRepository, VeiculoLinhaRepository>();

            services.AddScoped<LinhaService>();
            services.AddScoped<VeiculoService>();
            services.AddScoped<ParadaService>();
            services.AddScoped<PosicaoVeiculoService>();
        }
    }
}
