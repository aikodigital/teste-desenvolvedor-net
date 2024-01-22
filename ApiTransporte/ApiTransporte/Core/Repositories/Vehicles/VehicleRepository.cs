using ApiTransporte.Core.Data.Contexts;
using ApiTransporte.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTransporte.Core.Repositories.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly TransporteContext _context;

        public VehicleRepository(TransporteContext context)
        {
            _context = context;
        }

        public Vehicle Create(Vehicle model)
        {
            _context.Vehicles.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteById(long id)
        {
            var result = _context.Vehicles.Find(id);
            if (result is not null)
            {
                _context.Vehicles.Remove(result);
                _context.SaveChanges();
            }
        }

        public bool ExistsById(long id)
        {
            return _context.Vehicles.Any(j => j.Id == id);
        }

        public ICollection<Vehicle> FindAll()
        {
            return _context.Vehicles.AsNoTracking().ToList();
        }

        public Vehicle? FindById(long id)
        {
            return _context.Vehicles.AsNoTracking().FirstOrDefault(v => v.Id == id);
        }

        public Vehicle Update(Vehicle model)
        {
            _context.Vehicles.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
