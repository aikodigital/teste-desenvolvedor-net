using System.Threading.Tasks;
using Infra;
using Services.Interfaces;

namespace Services.Veiculo
{
    public class ObterVeiculoPorId : IServiceScoped
    {
        private readonly ApplicationContext context;

        public ObterVeiculoPorId(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Domain.Entities.Veiculo> Executar(long id)
        {
            var veiculo = await context.Veiculos.FindAsync(id);

            return veiculo;
        }
    }
}