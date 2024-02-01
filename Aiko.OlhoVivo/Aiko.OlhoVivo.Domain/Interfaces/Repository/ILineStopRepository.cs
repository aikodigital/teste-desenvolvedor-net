using Aiko.OlhoVivo.Infrastructure.Dto;

namespace Aiko.OlhoVivo.Domain.Interfaces.Repository;

public interface ILineStopRepository : IRepositorioBase<LineStop>
{
    Task <IEnumerable<LineStop>> ListAsyncLineStops(long id);
}
