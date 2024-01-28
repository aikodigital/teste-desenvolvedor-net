using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Core.Domain.Interfaces;

public interface IVehiclePositionRepository
{
    Task<IEnumerable<VehiclePosition>> GetAll();
    Task<VehiclePosition> GetById(long id);
    Task<VehiclePosition> Create(VehiclePosition vehiclePosition);
    Task<VehiclePosition> Update(VehiclePosition vehiclePosition);
    Task<VehiclePosition> Delete(VehiclePosition vehiclePosition);
}
