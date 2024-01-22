using ApiTransporte.Core.Models;

namespace ApiTransporte.Api.Vehicles.Services
{
    public interface IVehicleService
    {
        ICollection<Vehicle> FindAll();
        Vehicle FindById(long id);
        Vehicle Create(Vehicle vehicle);
        Vehicle UpdateById(long id, Vehicle vehicle);
        void DeleteById(long id);
        List<Vehicle> GetVehiclesByLineId(long lineId);
    }
}
