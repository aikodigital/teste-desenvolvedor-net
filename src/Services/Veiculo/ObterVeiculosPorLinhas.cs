using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Veiculo
{
    public class ObterVeiculosPorLinhas : IServiceScoped
    {
        private readonly ApplicationContext context;

        public ObterVeiculosPorLinhas(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Domain.Entities.Veiculo>> Executar(long id)
        {
            var veiculos = await context.Linhas
                .Include(x => x.Veiculos)
                .Where(x => x.Id == id)
                .Select(x => x.Veiculos)
                .FirstOrDefaultAsync();

            return veiculos;
        }
    }
}