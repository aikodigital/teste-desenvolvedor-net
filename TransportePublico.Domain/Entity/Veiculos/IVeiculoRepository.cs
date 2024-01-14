
namespace TransportePublico.Domain.Entity.Veiculos
{
    public interface IVeiculoRepository
    {
        Task<List<Veiculo>> GetAll();
        Task<Veiculo> GetById(long id);
        // void Add(Linha linha);
        // void Update(Linha linha);
        // void Remove(Linha linha);
    }
}