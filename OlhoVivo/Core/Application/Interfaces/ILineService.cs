using OlhoVivo.Core.Application.DTOs;

namespace OlhoVivo.Core.Application.Interfaces;

public interface ILineService
{
    Task<IEnumerable<LineDTO>> GetAll();
    Task<LineDTO> GetById(long id);
    Task Create(LineDTO lineDTO);
    Task Update(LineDTO lineDTO);
    Task Delete(long id);
}
