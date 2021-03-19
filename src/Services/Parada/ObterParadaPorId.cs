using System.Threading.Tasks;
using Infra;
using Services.Commons;

namespace Services.Parada
{
    public class ObterParadaPorId : BaseService
    {
        public ObterParadaPorId(ApplicationContext context) : base(context)
        {
        }

        public async Task<Domain.Entities.Parada> Executar(long id)
        {
            var parada = await context.Paradas.FindAsync(id);

            return parada;
        }
    }
}