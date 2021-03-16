using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;

namespace Services.Parada
{
    public class DeletarParada : BaseService
    {
        public DeletarParada(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(long id)
        {
            const string query = "DELETE FROM [dbo].[Paradas] WHERE [Id]={0}";
            await context.Database.ExecuteSqlRawAsync(query, id);
        }
    }
}