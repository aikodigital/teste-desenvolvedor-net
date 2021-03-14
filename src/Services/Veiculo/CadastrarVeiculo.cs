using System.Threading.Tasks;
using Infra;
using Services.Commons.Dtos;
using Services.Interfaces;

namespace Services.Veiculo
{
    public class CadastrarVeiculo : IServiceScoped
    {
        private readonly ApplicationContext context;

        public CadastrarVeiculo(ApplicationContext context)
        {
            this.context = context;
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