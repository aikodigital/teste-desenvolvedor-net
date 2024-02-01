using Aiko.OlhoVivo.Infrastructure.Dto;

namespace Aiko.OlhoVivo.Domain.Interfaces.Repository;

public interface ILineRepository : IRepositorioBase<Line>
{
    Task<IEnumerable<Line>> ListAsync(long? id);
}