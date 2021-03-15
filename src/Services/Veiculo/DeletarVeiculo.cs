using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
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
            const string query = "DELETE FROM [dbo].[Veiculos] WHERE [Id]={0}";
            await context.Database.ExecuteSqlRawAsync(query, id);
        }
    }
}