using System.Threading.Tasks;
using Infra;
using Services.Commons;
using Services.Commons.Dtos;

namespace Services.Veiculo
{
    public class CadastrarVeiculo : BaseService
    {
        public CadastrarVeiculo(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(VeiculoDto veiculoDto)
        {
            var veiculo = new Domain.Entities.Veiculo(
                veiculoDto.Nome,
                veiculoDto.Modelo,
                new Domain.ValueObjects.Localizacao(
                    veiculoDto.LocalizacaoDto.Latitude,
                    veiculoDto.LocalizacaoDto.Longitude
                )
            );

            await context.AddAsync(veiculo);
            await context.SaveChangesAsync();
        }
    }
}