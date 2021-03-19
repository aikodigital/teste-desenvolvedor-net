using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;

namespace Services.Linha
{
    public class ListarTodasAsLinhas : BaseService
    {
        public ListarTodasAsLinhas(ApplicationContext context) : base(context)
        {
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