
namespace TransportePublico.Domain.Entity.Linhas
{
    public interface ILinhaRepository
    {
        Task<IEnumerable<Linha>> GetAll();
        Task<Linha> GetById(long id);
        Task<bool> Add(Linha linha);
        Task<bool> Update(Linha linha);
        Task<bool> Remove(Linha linha);
    }
}