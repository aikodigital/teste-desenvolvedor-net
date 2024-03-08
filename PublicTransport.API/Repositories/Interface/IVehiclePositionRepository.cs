using System.Collections.Generic;
using System.Threading.Tasks;
using PublicTransport.API.Entities;

namespace PublicTransport.API.Repositories.Interface;

public interface IVehiclePositionRepository
{
    Task<IEnumerable<VehiclePosition>> GetAllAsync();

    Task<VehiclePosition> GetByIdAsync(long id);

    Task CreateAsync(VehiclePosition vehiclePosition);

    Task UpdateAsync(VehiclePosition vehiclePosition);

    Task DeleteAsync(long id);
}
