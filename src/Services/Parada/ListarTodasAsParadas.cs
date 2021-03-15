using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Parada
{
    public class ListarTodasAsParadas : IServiceScoped
    {
        private readonly ApplicationContext context;

        public ListarTodasAsParadas(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<Domain.Entities.Parada>> Executar()
        {
            var paradas = await context.Paradas.ToListAsync();

            return paradas;
        }
    }
}