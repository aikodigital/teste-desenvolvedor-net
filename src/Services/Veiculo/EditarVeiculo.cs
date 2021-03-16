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

        public async Task Executar(long id, VeiculoDto veiculoDto)
        {
            var veiculoExiste = await context.Veiculos.AnyAsync(x => x.Id == id);

            if (veiculoExiste) {
                var veiculo = new Domain.Entities.Veiculo(
                    veiculoDto.Nome,
                    veiculoDto.Modelo,
                    new Domain.ValueObjects.Localizacao(
                        veiculoDto.LocalizacaoDto.Latitude,
                        veiculoDto.LocalizacaoDto.Longitude
                    ),
                    id: id
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