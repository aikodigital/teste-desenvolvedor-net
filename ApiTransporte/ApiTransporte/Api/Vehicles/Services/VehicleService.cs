using ApiTransporte.Core.Data.Contexts;
using ApiTransporte.Core.Exceptions;
using ApiTransporte.Core.Models;
using ApiTransporte.Core.Repositories.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace ApiTransporte.Api.Vehicles.Services
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository _vehicleRepository;
        private readonly TransporteContext _context;

        public VehicleService(IVehicleRepository vehicleRepository, TransporteContext context)
        {
            _vehicleRepository = vehicleRepository;
            _context = context;
        }

        public Vehicle Create(Vehicle vehicle)
        {
            return _vehicleRepository.Create(vehicle);
        }

        public void DeleteById(long id)
        {
            if (!_vehicleRepository.ExistsById(id))
            {
                throw new CustomNotFoundException($"Vehicle with id {id} not found");
            }
            _vehicleRepository.DeleteById(id);
        }

        public ICollection<Vehicle> FindAll()
        {
            return _vehicleRepository.FindAll();
        }

        public Vehicle FindById(long id)
        {
            var result = _vehicleRepository.FindById(id);
            if (result is null)
            {
                throw new CustomNotFoundException($"Vehicle with id {id} not found");
            }
            return result;
        }

        public Vehicle UpdateById(long id, Vehicle vehicle)
        {
            if (!_vehicleRepository.ExistsById(id))
            {
                throw new CustomNotFoundException($"Vehicle with id {id} not found");
            }
            vehicle.Id = id;
            var updateVehicle = _vehicleRepository.Update(vehicle);
            return updateVehicle;
        }

        public List<Vehicle> GetVehiclesByLineId(long lineId)
        {
            return _context.Vehicles
             .Include(v => v.Line)
             .Where(v => v.LineId == lineId)
             .ToList();
        }
    }
}
