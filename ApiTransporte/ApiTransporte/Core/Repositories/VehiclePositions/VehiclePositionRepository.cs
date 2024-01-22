using ApiTransporte.Core.Data.Contexts;
using ApiTransporte.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTransporte.Core.Repositories.VehiclePositions
{
    public class VehiclePositionRepository : IVehiclePositionRepository
    {
        private readonly TransporteContext _context;

        public VehiclePositionRepository(TransporteContext context)
        {
            _context = context;
        }

        public VehiclePosition Create(VehiclePosition model)
        {
            _context.VehiclePositions.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteById(long id)
        {
            var result = _context.VehiclePositions.Find(id);
            if (result is not null)
            {
                _context.VehiclePositions.Remove(result);
                _context.SaveChanges();
            }
        }

        public bool ExistsById(long id)
        {
            return _context.VehiclePositions.Any(v => v.Id == id);
        }

        public ICollection<VehiclePosition> FindAll()
        {
            return _context.VehiclePositions.AsNoTracking().ToList();
        }

        public VehiclePosition? FindById(long id)
        {
            return _context.VehiclePositions.AsNoTracking().FirstOrDefault(v => v.Id == id);
        }
      
        public VehiclePosition Update(VehiclePosition model)
        {
            _context.VehiclePositions.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
