using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Services.DTOs;
using TesteDesenvolvedor.Services.Utils;

namespace TesteDesenvolvedor.Services.Interface
{
    public interface IParadaService
    {
        Task<ParadaDTO> FindByIdParadaAsync(long id);
        Task<List<ParadaDTO>> GetAllParadasAsync();
        Task<ParadaDTO> AddParadaAsync(Parada parada);
        Task<List<ParadaPosicaoDTO>> FindParadaByPosicao(double lat, double lng, double distance);
        Task<ParadaDTO> UpdateParadaAsync(long id, ParadaDTO parada);
        Task<PageList<ParadaDTO>> FindByNameSearchPage(string nome, int page, int pageSize);

        Task<bool> DeleteParadaAsync(long id);
    }
}