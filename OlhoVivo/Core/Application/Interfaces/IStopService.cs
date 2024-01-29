using OlhoVivo.Core.Application.DTOs;

namespace OlhoVivo.Core.Application.Interfaces;

public interface IStopService
{
    Task<IEnumerable<StopDTO>> GetAll();
    Task<IEnumerable<StopDTO>> GetStopsByLine(long lineId);
    Task<StopDTO> GetById(long id);
    Task Create(StopDTO stopDTO);
    Task Update(StopDTO stopDTO);
    Task Delete(long id);
}
