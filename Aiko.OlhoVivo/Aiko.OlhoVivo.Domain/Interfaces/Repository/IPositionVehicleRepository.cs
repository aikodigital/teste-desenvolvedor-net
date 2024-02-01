using Aiko.OlhoVivo.Infrastructure.Dto;

namespace Aiko.OlhoVivo.Domain.Interfaces.Repository;

public interface IPositionVehicleRepository : IRepositorioBase<VehiclePosition>
{
    Task<IEnumerable<VehiclePosition>> ListAsync(long? id);
}