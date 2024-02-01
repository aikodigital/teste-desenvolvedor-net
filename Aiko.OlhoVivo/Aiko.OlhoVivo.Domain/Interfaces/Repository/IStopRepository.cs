using Aiko.OlhoVivo.Infrastructure.Dto;

namespace Aiko.OlhoVivo.Domain.Interfaces.Repository;

public interface IStopRepository : IRepositorioBase<Stop>
{
    Task<IEnumerable<Stop>> ListAsync(long? id);
}
