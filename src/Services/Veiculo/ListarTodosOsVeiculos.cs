using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Veiculo
{
    public class ListarTodosOsVeiculos : IServiceScoped
    {
        private readonly ApplicationContext context;

        public ListarTodosOsVeiculos(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<Domain.Entities.Veiculo>> Executar()
        {
            var veiculos = await context.Veiculos.ToListAsync();

            return veiculos;
        }
    }
}