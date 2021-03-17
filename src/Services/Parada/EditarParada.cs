using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;
using Services.Commons.Dtos;

namespace Services.Parada
{
    public class EditarParada : BaseService
    {
        public EditarParada(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(ParadaDto paradaDto)
        {
            var paradaExiste = await context.Paradas.AnyAsync(x => x.Id == paradaDto.Id);

            if (paradaExiste) {
                var parada = new Domain.Entities.Parada(
                    paradaDto.Nome,
                    new Domain.ValueObjects.Localizacao(
                        paradaDto.Localizacao.Latitude,
                        paradaDto.Localizacao.Longitude
                    ),
                    id: paradaDto.Id
                );

                context.Update(parada);
                await context.SaveChangesAsync();
            }
            else {
                Notifications.Add("not-found", "Parada não encontrado!");
            }
        }
    }
}