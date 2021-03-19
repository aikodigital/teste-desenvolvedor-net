using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;
using Services.Commons.Dtos;

namespace Services.Veiculo
{
    public class EditarVeiculo : BaseService
    {
        public EditarVeiculo(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(VeiculoDto veiculoDto)
        {
            var veiculoExiste = await context.Veiculos.AnyAsync(x => x.Id == veiculoDto.Id);

            if (veiculoExiste) {
                var veiculo = new Domain.Entities.Veiculo(
                    veiculoDto.Nome,
                    veiculoDto.Modelo,
                    new Domain.ValueObjects.Localizacao(
                        veiculoDto.Localizacao.Latitude,
                        veiculoDto.Localizacao.Longitude
                    ),
                    id: veiculoDto.Id
                );

                context.Update(veiculo);
                await context.SaveChangesAsync();
            }
            else {
                Notifications.Add("not-found", "Veículo não encontrado!");
            }
        }
    }
}