using PublicTransport.API.Entities;

namespace PublicTransport.API.Repositories.Interface;

public interface IStopRepository
{
    Task<IEnumerable<Stop>> GetAllAsync();

    Task<Stop> GetByIdAsync(long id);

    Task CreateAsync(Stop stop);

    Task CreateWithLineAsync(Stop stop, long lineId);

    Task UpdateAsync(Stop stop);

    Task DeleteAsync(long id);
}
