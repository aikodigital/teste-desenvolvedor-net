using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;

namespace Services.Parada
{
    public class ListarTodasAsParadas : BaseService
    {
        public ListarTodasAsParadas(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<Domain.Entities.Parada>> Executar()
        {
            var paradas = await context.Paradas.ToListAsync();

            return paradas;
        }
    }
}