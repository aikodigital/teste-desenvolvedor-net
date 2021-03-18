using System.Threading.Tasks;
using Infra;
using Services.Commons;

namespace Services.Veiculo
{
    public class ObterVeiculoPorId : BaseService
    {
        public ObterVeiculoPorId(ApplicationContext context) : base(context)
        {
        }

        public async Task<Domain.Entities.Veiculo> Executar(long id)
        {
            var veiculo = await context.Veiculos.FindAsync(id);

            return veiculo;
        }
    }
}