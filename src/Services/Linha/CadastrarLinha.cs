using System.Threading.Tasks;
using Infra;
using Services.Commons.Dtos;
using Services.Interfaces;

namespace Services.Linha
{
    public class CadastrarLinha : IServiceScoped
    {
        private readonly ApplicationContext context;

        public CadastrarLinha(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task Executar(LinhaDto linhaDto)
        {
            var linha = new Domain.Entities.Linha(
                linhaDto.Nome
            );

            await context.AddAsync(linha);
            await context.SaveChangesAsync();
        }
    }
}