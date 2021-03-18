using System;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    public class BaseTeste : IDisposable
    {
        protected readonly ApplicationContext context;

        protected BaseTeste()
        {
            context = new ApplicationContext(ObterConfiguracoes());
        }

        private static DbContextOptions<ApplicationContext> ObterConfiguracoes()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("DbTeste")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        public void Dispose() => context.Dispose();
    }
}