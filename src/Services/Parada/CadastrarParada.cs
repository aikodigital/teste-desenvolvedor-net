using System.Threading.Tasks;
using Infra;
using Services.Commons.Dtos;
using Services.Interfaces;

namespace Services.Parada
{
    public class CadastrarParada : IServiceScoped
    {
        private readonly ApplicationContext context;

        public CadastrarParada(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task Executar(ParadaDto paradaDto)
        {
            var parada = new Domain.Entities.Parada(
                paradaDto.Nome,
                new Domain.ValueObjects.Localizacao(
                    paradaDto.LocalizacaoDto.Latitude,
                    paradaDto.LocalizacaoDto.Longitude
                )
            );

            await context.AddAsync(parada);
            await context.SaveChangesAsync();
        }
    }
}