using System.Linq;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;
using Services.Commons.Dtos;

namespace Services.Linha
{
    public class VincularParada : BaseService
    {
        public VincularParada(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(ParadaNaLinhaDto paradaNaLinhaDto)
        {
            var linha = await context.Linhas
                .Include(x => x.Paradas)
                .SingleOrDefaultAsync(x => x.Id == paradaNaLinhaDto.LinhaId);

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