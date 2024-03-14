using PublicTransport.API.Entities;

namespace PublicTransport.API.Repositories.Interface;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetAllAsync();

    Task<Vehicle> GetByIdAsync(long id);

    Task CreateAsync(Vehicle vehicle);

    Task UpdateAsync(Vehicle vehicle);

    Task DeleteAsync(long id);
}
