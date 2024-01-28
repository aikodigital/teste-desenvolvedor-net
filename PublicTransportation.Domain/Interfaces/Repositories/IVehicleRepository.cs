using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Domain.Interfaces.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {

        public VehiclePosition GetVehiclePositionByVehicleId(long vehicleId);

        public bool HasVehiclesInLine(long lineId);

        public void CreateVehiclePosition(VehiclePosition vehiclePosition);

        public void UpdateVehiclePosition(VehiclePosition vehiclePosition);

        public void DeleteVehiclePosition(VehiclePosition vehiclePosition);

        public bool VehicleHasPosition(long vehicleId);
    }
}
