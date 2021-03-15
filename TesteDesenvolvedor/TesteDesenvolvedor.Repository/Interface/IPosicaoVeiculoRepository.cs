using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Generic;

namespace TesteDesenvolvedor.Repository.Interface
{
    public interface IPosicaoVeiculoRepository : IRepository
    {
        Task<PosicaoVeiculo> FindByIdAsync(long veiculoId);
        Task<PosicaoVeiculo> FindByIdVeiculoAsync(long VeiculoId);

        Task<List<PosicaoVeiculo>> GetAllAsync();
    }
}