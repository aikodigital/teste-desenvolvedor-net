
namespace TransportePublico.Domain.Entity.Veiculos
{
    public interface IVeiculoRepository
    {
        Task<List<Veiculo>> GetAll();
        Task<Veiculo> GetById(long id);
        Task<bool> Add(Veiculo veiculo);
        Task<bool> Update(Veiculo veiculo);
        Task<bool> Remove(Veiculo veiculo);
        Task<IEnumerable<Veiculo>> GetVeiculosByLinha(long linhaId);
    }
}