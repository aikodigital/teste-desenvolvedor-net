using PublicTransport.API.Entities;

namespace PublicTransport.API.Repositories.Interface;

public interface ILineStopRepository
{
    Task<IEnumerable<Line>> GetLinesByStopIdAsync(long stopId);

    Task AddStopByLineAsync(long lineId, long stopId);
}
