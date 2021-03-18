using System.Linq;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;
using Services.Commons.Dtos;

namespace Services.Linha
{
    public class VincularVeiculo : BaseService
    {
        public VincularVeiculo(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(VeiculoNaLinhasDto veiculoNaLinhaDto)
        {
            var linha = await context.Linhas
                .Include(x => x.Veiculos)
                .SingleOrDefaultAsync(x => x.Id == veiculoNaLinhaDto.LinhaId);

            var veiculo = await context.Veiculos.FindAsync(veiculoNaLinhaDto.VeiculoId);

            if (linha is null)
                Notifications.Add("linha-nao-encontrada", "Linha não encontrada!");

            if (veiculo is null)
                Notifications.Add("veiculo-nao-encontrado", "Parada não encontrada!");

            if (!Notifications.Any()) {
                linha.AdicionarVeiculo(veiculo);

                await context.SaveChangesAsync();
            }
        }
    }
}