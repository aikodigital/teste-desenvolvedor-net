using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Services.Interfaces;

namespace Services.Veiculo
{
    public class DeletarVeiculo : IServiceScoped
    {
        private readonly ApplicationContext context;
        public readonly IDictionary<string, string> Notifications;

        public DeletarVeiculo(ApplicationContext context)
        {
            this.context = context;
            Notifications = new Dictionary<string, string>();
        }

        public async Task Executar(long id)
        {
            var veiculo = await context.Veiculos.FindAsync(id);

            if (veiculo is null) {
                Notifications.Add("not-found", "Veículo não encontrado!");
                
                return;
            }

            context.Remove(veiculo);
            await context.SaveChangesAsync();
        }
    }
}