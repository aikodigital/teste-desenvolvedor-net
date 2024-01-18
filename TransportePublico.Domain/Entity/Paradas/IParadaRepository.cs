
namespace TransportePublico.Domain.Entity.Paradas
{
    public interface IParadaRepository
    {
        Task<List<Parada>> GetAll();
        Task<Parada> GetById(long id);
        Task<bool> Add(Parada parada);
        Task<bool> Update(Parada parada);
        Task<bool> Remove(Parada parada);
    }
}