using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Core.Domain.Interfaces;

public interface ILineRepository
{
    Task<IEnumerable<Line>> GetAll();
    Task<Line> GetById(long id);
    Task<Line> Create(Line line);
    Task<Line> Update(Line line);
    Task<Line> Delete(Line line);
}
