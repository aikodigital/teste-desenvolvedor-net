using ApiTransporte.Core.Exceptions;
using ApiTransporte.Core.Models;
using ApiTransporte.Core.Repositories.VehiclePositions;

namespace ApiTransporte.Api.VehiclePositions.Services
{
    public class VehiclePositionService : IVehiclePositionService
    {
        private readonly IVehiclePositionRepository _vehiclePositionRepository;

        public VehiclePositionService(IVehiclePositionRepository vehiclePositionRepository)
        {
            _vehiclePositionRepository = vehiclePositionRepository;
        }

        public VehiclePosition Create(VehiclePosition vehiclePosition)
        {
            return _vehiclePositionRepository.Create(vehiclePosition);
        }

        public void DeleteById(long id)
        {
            if (!_vehiclePositionRepository.ExistsById(id))
            {
                throw new CustomNotFoundException($"VehiclePosition with id {id} not found");
            }
            _vehiclePositionRepository.DeleteById(id);
        }

        public ICollection<VehiclePosition> FindAll()
        {
            return _vehiclePositionRepository.FindAll();
        }

        public VehiclePosition FindById(long id)
        {
            var result = _vehiclePositionRepository.FindById(id);
            if (result is null)
            {
                throw new CustomNotFoundException($"VehiclePosition with id {id} not found");
            }
            return result;
        }

        public VehiclePosition UpdateById(long id, VehiclePosition vehiclePosition)
        {
            if (!_vehiclePositionRepository.ExistsById(id))
            {
                throw new CustomNotFoundException($"VehiclePosition with id {id} not found");
            }
            vehiclePosition.Id = id;
            var updateVehiclePosition = _vehiclePositionRepository.Update(vehiclePosition);
            return updateVehiclePosition;
        }
    }
}
