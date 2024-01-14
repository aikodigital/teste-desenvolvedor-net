
namespace TransportePublico.Domain.Entity.Paradas
{
    public interface IParadaRepository
    {
        Task<List<Parada>> GetAll();
        Task<Parada> GetById(long id);
        // void Add(Linha linha);
        // void Update(Linha linha);
        // void Remove(Linha linha);
    }
}