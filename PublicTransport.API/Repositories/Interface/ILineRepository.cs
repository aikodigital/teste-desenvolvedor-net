using PublicTransport.API.Entities;

namespace PublicTransport.API.Repositories.Interface;

public interface ILineRepository
{
    Task<IEnumerable<Line>> GetAllAsync();

    Task<Line> GetByIdAsync(long id);

    Task<Line> PostAsync(Line line);

    Task<Line> UpdateAsync(Line line);

    Task DeleteAsync(long id);
}
