using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Core.Domain.Interfaces;

public interface IStopRepository
{
    Task<IEnumerable<Stop>> GetAll();
    Task<IEnumerable<Stop>> GetStopsByLine(long lineId);
    Task<Stop> GetById(long id);
    Task<Stop> Create(Stop stop);
    Task<Stop> Update(Stop stop);
    Task<Stop> Delete(Stop stop);
}
