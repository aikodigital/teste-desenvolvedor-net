using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra;
using Services.Commons.Dtos;
using Services.Interfaces;

namespace Services.Linha
{
    public class VincularParada : IServiceScoped
    {
        private readonly ApplicationContext context;
        public readonly IDictionary<string, string> Notifications;

        public VincularParada(ApplicationContext context)
        {
            this.context = context;
            Notifications = new Dictionary<string, string>();
        }

        public async Task Executar(ParadaNaLinhaDto paradaNaLinhaDto)
        {
            var linha = await context.Linhas.FindAsync(paradaNaLinhaDto.LinhaId);
            var parada = await context.Paradas.FindAsync(paradaNaLinhaDto.ParadaId);

            if (linha is null)
                Notifications.Add("linha-nao-encontrada", "Linha não encontrada!");

            if (parada is null)
                Notifications.Add("parada-nao-encontrada", "Parada não encontrada!");

            if (linha is not null && linha.Paradas.Any(x => x.Id == paradaNaLinhaDto.ParadaId))
                Notifications.Add("parada-vinculada", "Esta parada já está vinculada a esta linha!");

            if (!Notifications.Any()) {
                linha.AdicionarParada(parada);

                await context.SaveChangesAsync();
            }
        }
    }
}