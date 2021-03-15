using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Linha
{
    public class ListarTodasAsLinhas : IServiceScoped
    {
        private readonly ApplicationContext context;

        public ListarTodasAsLinhas(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<List<Domain.Entities.Linha>> Executar()
        {
            var linhas = await context.Linhas
                .Include(x => x.Paradas)
                .ToListAsync();

            return linhas;
        }
    }
}