using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Generic;

namespace TesteDesenvolvedor.Repository.Interface
{
    public interface IParadaRepository : IRepository
    {
        Task<Parada> FindByIdAsync(long id);
        Task<List<Parada>> GetAllAsync();

        Task<List<Parada>> FindParadaByPosicao(double lat, double lng, double distancia);
        Task<List<Parada>> FindByNameSearchPage(string nome, int offset, int pageSize);
        int GetCount(string nome);

    }
}