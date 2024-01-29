using OlhoVivo.Core.Application.DTOs;

namespace OlhoVivo.Core.Application.Interfaces;

public interface IVehiclePositionService
{
    Task<IEnumerable<VehiclePositionDTO>> GetAll();
    Task<VehiclePositionDTO> GetById(long id);
    Task Create(VehiclePositionDTO vehiclePositionDTO);
    Task Update(VehiclePositionDTO vehiclePositionDTO);
    Task Delete(long idV);
}
