using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;

namespace Services.Veiculo
{
    public class ListarTodosOsVeiculos : BaseService
    {
        public ListarTodosOsVeiculos(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Domain.Entities.Veiculo>> Executar()
        {
            var veiculos = await context.Veiculos.ToListAsync();

            return veiculos;
        }
    }
}