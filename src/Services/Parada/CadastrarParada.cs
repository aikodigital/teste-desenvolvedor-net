using System.Threading.Tasks;
using Infra;
using Services.Commons;
using Services.Commons.Dtos;

namespace Services.Parada
{
    public class CadastrarParada : BaseService
    {
        public CadastrarParada(ApplicationContext context) : base(context)
        {
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