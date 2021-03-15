using System.Threading.Tasks;
using Infra;
using Services.Interfaces;

namespace Services.Parada
{
    public class ObterParadaPorId : IServiceScoped
    {
        private readonly ApplicationContext context;

        public ObterParadaPorId(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Domain.Entities.Parada> Executar(long id)
        {
            var parada = await context.Paradas.FindAsync(id);

            return parada;
        }
    }
}