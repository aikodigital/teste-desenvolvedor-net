using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Core.Domain.Interfaces;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetAll();
    Task<IEnumerable<Vehicle>> GetVehiclesByLine(long lineId);
    Task<Vehicle> GetById(long id);
    Task<Vehicle> Create(Vehicle vehicle);
    Task<Vehicle> Update(Vehicle vehicle);
    Task<Vehicle> Delete(Vehicle vehicle);
}
