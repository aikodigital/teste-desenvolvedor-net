using OlhoVivo.Core.Application.DTOs;

namespace OlhoVivo.Core.Application.Interfaces;

public interface IVehicleService
{
    Task<IEnumerable<VehicleDTO>> GetAll();
    Task<IEnumerable<VehicleDTO>> GetVehiclesByLine(long lineId);
    Task<VehicleDTO> GetById(long id);
    Task Create(VehicleDTO vehicleDTO);
    Task Update(VehicleDTO vehicleDTO);
    Task Delete(long id);
}
