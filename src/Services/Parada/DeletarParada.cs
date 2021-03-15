using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Parada
{
    public class DeletarParada : IServiceScoped
    {
        private readonly ApplicationContext context;
        public readonly IDictionary<string, string> Notifications;

        public DeletarParada(ApplicationContext context)
        {
            this.context = context;
            Notifications = new Dictionary<string, string>();
        }

        public async Task Executar(long id)
        {
            const string query = "DELETE FROM [dbo].[Paradas] WHERE [Id]={0}";
            await context.Database.ExecuteSqlRawAsync(query, id);
        }
    }
}