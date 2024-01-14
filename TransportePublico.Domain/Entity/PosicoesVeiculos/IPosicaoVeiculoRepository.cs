
namespace TransportePublico.Domain.Entity.PosicoesVeiculos
{
    public interface IPosicaoVeiculoRepository
    {
        Task<List<PosicaoVeiculo>> GetAll();
        Task<PosicaoVeiculo> GetById(long id);
        // void Add(Linha linha);
        // void Update(Linha linha);
        // void Remove(Linha linha);
    }
}