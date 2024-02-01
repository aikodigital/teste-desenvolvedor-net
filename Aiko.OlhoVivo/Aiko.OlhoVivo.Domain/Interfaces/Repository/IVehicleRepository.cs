using Aiko.OlhoVivo.Infrastructure.Dto;

namespace Aiko.OlhoVivo.Domain.Interfaces.Repository;

public interface IVehicleRepository : IRepositorioBase<Vehicle>
{
    Task<IEnumerable<Vehicle>> ListAsync(long? id);
    Task<IEnumerable<Vehicle>> ListAsyncVehicleLine(long id);
}