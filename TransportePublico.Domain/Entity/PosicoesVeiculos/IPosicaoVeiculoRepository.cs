
namespace TransportePublico.Domain.Entity.PosicoesVeiculos
{
    public interface IPosicaoVeiculoRepository
    {
        Task<List<PosicaoVeiculo>> GetAll();
        Task<PosicaoVeiculo> GetById(long id);
        Task<bool> Add(PosicaoVeiculo posicaoVeiculo);
        Task<bool> Update(PosicaoVeiculo posicaoVeiculo);
        Task<bool> Remove(PosicaoVeiculo posicaoVeiculo);
    }
}