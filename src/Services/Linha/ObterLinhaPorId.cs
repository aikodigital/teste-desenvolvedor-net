using System.Threading.Tasks;
using Infra;
using Services.Interfaces;

namespace Services.Linha
{
    public class ObterLinhaPorId : IServiceScoped
    {
        private readonly ApplicationContext context;

        public ObterLinhaPorId(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Domain.Entities.Linha> Executar(long id)
        {
            var linha = await context.Linhas.FindAsync(id);

            return linha;
        }
    }
}