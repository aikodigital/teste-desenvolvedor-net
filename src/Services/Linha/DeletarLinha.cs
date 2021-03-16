using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
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
            const string query = "DELETE FROM [dbo].[Linhas] WHERE [Id]={0}";
            await context.Database.ExecuteSqlRawAsync(query, id);
        }
    }
}