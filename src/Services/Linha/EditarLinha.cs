using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;
using Services.Commons.Dtos;

namespace Services.Linha
{
    public class EditarLinha : BaseService
    {
        public EditarLinha(ApplicationContext context) : base(context)
        {
        }

        public async Task Executar(LinhaDto linhaDto)
        {
            var linhaExiste = await context.Linhas.AnyAsync(x => x.Id == linhaDto.Id);

            if (linhaExiste) {
                var linha = new Domain.Entities.Linha(
                    linhaDto.Nome,
                    id: linhaDto.Id
                );

                context.Update(linha);
                await context.SaveChangesAsync();
            }
            else {
                Notifications.Add("not-found", "Linha não encontrada!");
            }
        }
    }
}