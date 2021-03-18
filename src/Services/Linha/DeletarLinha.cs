using System.Threading.Tasks;
using Infra;
using Services.Commons;

namespace Services.Linha
{
    public class DeletarLinha : BaseService
    {
        public DeletarLinha(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(long id)
        {
            var linha = await context.Linhas.FindAsync(id);

            if (linha is null) {
                Notifications.Add("not-found", "Linha não encontrada!");
            }
            else {
                context.Remove(linha);
                await context.SaveChangesAsync();
            }
        }
    }
}