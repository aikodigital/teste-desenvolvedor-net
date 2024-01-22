using ApiTransporte.Core.Data.Contexts;

namespace ApiTransporte.Core.Config
{
    public static class DatabaseConfig
    {
        public static void RegisterDatabase(this IServiceCollection services)
        {
            services.AddDbContext<TransporteContext>();
        }
    }
}
