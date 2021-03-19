using System.Threading.Tasks;
using Infra;
using Services.Commons;
using Services.Commons.Dtos;

namespace Services.Linha
{
    public class CadastrarLinha : BaseService
    {
        public CadastrarLinha(ApplicationContext context) : base(context)
        {
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