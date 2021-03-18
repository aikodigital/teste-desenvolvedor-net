using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;

namespace Services.Veiculo
{
    public class DeletarVeiculo : BaseService
    {
        public DeletarVeiculo(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(long id)
        {
            const string query = "DELETE FROM [dbo].[Veiculos] WHERE [Id]={0}";
            await context.Database.ExecuteSqlRawAsync(query, id);
        }
    }
}