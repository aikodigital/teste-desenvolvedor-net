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

        public async Task Executar(long id, ParadaDto paradaDto)
        {
            var paradaExiste = await context.Paradas.AnyAsync(x => x.Id == id);

            if (paradaExiste) {
                var parada = new Domain.Entities.Parada(
                    paradaDto.Nome,
                    new Domain.ValueObjects.Localizacao(
                        paradaDto.LocalizacaoDto.Latitude,
                        paradaDto.LocalizacaoDto.Longitude
                    ),
                    id: id
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