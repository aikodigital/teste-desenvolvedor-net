using ApiTransporte.Core.Models;

namespace ApiTransporte.Api.VehiclePositions.Services
{
    public interface IVehiclePositionService
    {
        ICollection<VehiclePosition> FindAll();
        VehiclePosition FindById(long id);
        VehiclePosition Create(VehiclePosition vehiclePosition);
        VehiclePosition UpdateById(long id, VehiclePosition vehiclePosition);
        void DeleteById(long id);
    }
}
