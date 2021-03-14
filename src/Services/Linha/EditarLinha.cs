using System.Collections.Generic;
using System.Threading.Tasks;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons.Dtos;
using Services.Interfaces;

namespace Services.Linha
{
    public class EditarLinha : IServiceScoped
    {
        private readonly ApplicationContext context;
        public readonly IDictionary<string, string> Notifications;

        public EditarLinha(ApplicationContext context)
        {
            this.context = context;
            Notifications = new Dictionary<string, string>();
        }

        public async Task Executar(long id, LinhaDto linhaDto)
        {
            var linhaExiste = await context.Linhas.AnyAsync(x => x.Id == id);

            if (linhaExiste) {
                var linha = new Domain.Entities.Linha(
                    linhaDto.Nome,
                    id: id
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