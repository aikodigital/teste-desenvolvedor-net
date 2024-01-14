
namespace TransportePublico.Domain.Entity.Linhas
{
    public interface ILinhaRepository
    {
        Task<List<Linha>> GetAll();
        Task<Linha> GetById(long id);
        // void Add(Linha linha);
        // void Update(Linha linha);
        // void Remove(Linha linha);
    }
}