using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;

namespace Services.Linha
{
    public class DesvincularParada : BaseService
    {
        public DesvincularParada(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(long linhaId, long paradaId)
        {
            var linha = await context.Linhas
                .Include(x => x.Paradas)
                .SingleOrDefaultAsync(x => x.Id == linhaId);

            linha.DesvincularParada(paradaId: paradaId);

            await context.SaveChangesAsync();
        }
    }
}