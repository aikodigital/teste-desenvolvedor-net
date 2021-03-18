using System.Linq;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;

namespace Services.Linha
{
    public class DesvincularVeiculo : BaseService
    {
        public DesvincularVeiculo(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(long id)
        {
            var linha = await context.Linhas
                .Include(x => x.Veiculos)
                .SingleOrDefaultAsync(x => x.Veiculos.Any(y => y.Id == id));

            linha.DesvincularVeiculo(veiculoId: id);

            await context.SaveChangesAsync();
        }
    }
}