using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons.Dtos;
using Services.Interfaces;

namespace Services.Parada
{
    public class EditarParada : IServiceScoped
    {
        private readonly ApplicationContext context;
        public readonly IDictionary<string, string> Notifications;

        public EditarParada(ApplicationContext context)
        {
            this.context = context;
            Notifications = new Dictionary<string, string>();
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