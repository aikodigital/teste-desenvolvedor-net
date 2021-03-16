using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Generic;

namespace TesteDesenvolvedor.Repository.Interface
{
    public interface IVeiculoRepository : IRepository
    {
        Task<Veiculo> FindByIdAsync(long id);
        Task<List<Veiculo>> GetAllAsync();
        Task<List<Veiculo>> FindAllVeiculosByLinhasAsync(long linhaId);
        Task<List<Veiculo>> FindByNameSearchPage(string nome, int offset, int pageSize);
        int GetCount(string nome);
    }
}