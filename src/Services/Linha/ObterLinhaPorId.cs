using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;

namespace Services.Linha
{
    public class ObterLinhaPorId : BaseService
    {
        public ObterLinhaPorId(ApplicationContext context) : base(context)
        {
        }

        public async Task<Domain.Entities.Linha> Executar(long id)
        {
            var linha = await context.Linhas
                .Include(x => x.Veiculos)
                .Include(x => x.Paradas)
                .SingleOrDefaultAsync(x => x.Id == id);

            return linha;
        }
    }
}