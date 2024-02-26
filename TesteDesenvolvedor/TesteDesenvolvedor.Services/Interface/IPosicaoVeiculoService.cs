using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Services.DTOs;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface IPosicaoVeiculoService
    {
        Task<PosicaoVeiculoDTO> FindByIdPosicaoVeiculoAsync(long veiculoId);
        Task<List<PosicaoVeiculoDTO>> GetAllPosicaoVeiculosAsync();
        Task<PosicaoVeiculoDTO> AddPosicaoVeiculoAsync(PosicaoVeiculoDTO posicaoVeiculo);
        Task<PosicaoVeiculoDTO> UpdatePosicaoVeiculoAsync(long veiculoId, PosicaoVeiculoDTO posicaoVeiculo);
        Task<bool> DeletePosicaoVeiculoAsync(long veiculoId);
    }
}