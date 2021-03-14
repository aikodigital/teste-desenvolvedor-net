using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Services.Interfaces;

namespace Services.Linha
{
    public class DeletarLinha : IServiceScoped
    {
        private readonly ApplicationContext context;
        public readonly IDictionary<string, string> Notifications;

        public DeletarLinha(ApplicationContext context)
        {
            this.context = context;
            Notifications = new Dictionary<string, string>();
        }

        public async Task Executar(long id)
        {
            var linha = await context.Linhas.FindAsync(id);

            if (linha is null) {
                Notifications.Add("not-found", "Linha não encontrada!");

                return;
            }

            context.Remove(linha);
            await context.SaveChangesAsync();
        }
    }
}