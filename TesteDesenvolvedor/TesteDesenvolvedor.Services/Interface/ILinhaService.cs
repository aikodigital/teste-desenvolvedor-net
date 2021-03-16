using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Services.DTOs;
using TesteDesenvolvedor.Services.Utils;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface ILinhaService
    {
        Task<LinhaDTO> FindByIdLinhaAsync(long id);
        Task<List<LinhaDTO>> GetAllLinhasAsync();
        Task<LinhaDTO> AddLinhaAsync(Linha linha);
        Task<LinhaDTO> UpdateLinhaAsync(long id, LinhaDTO linha);
        Task<bool> DeleteLinhaAsync(long id);
        Task<List<LinhaParadasDTO>> FindAllLinhasByParadasAsync(long paradaId);
        Task<PageList<LinhaDTO>> FindByNameSearchPage(string nome, int page, int pageSize);
    }
}