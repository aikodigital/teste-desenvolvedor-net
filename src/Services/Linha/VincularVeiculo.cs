using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons.Dtos;
using Services.Interfaces;

namespace Services.Linha
{
    public class VincularVeiculo : IServiceScoped
    {
        private readonly ApplicationContext context;
        public readonly IDictionary<string, string> Notifications;

        public VincularVeiculo(ApplicationContext context)
        {
            this.context = context;
            Notifications = new Dictionary<string, string>();
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

            if (linha is not null && linha.Veiculos.Any(x => x.Id == veiculoNaLinhaDto.VeiculoId))
                Notifications.Add("veiculo-vinculado", "Este veículo já está vinculado a esta linha!");

            if (!Notifications.Any()) {
                linha.AdicionarVeiculo(veiculo);

                await context.SaveChangesAsync();
            }
        }
    }
}