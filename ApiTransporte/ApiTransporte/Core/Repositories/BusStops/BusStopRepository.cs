using ApiTransporte.Core.Data.Contexts;
using ApiTransporte.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTransporte.Core.Repositories.BusStops
{
    public class BusStopRepository : IBusStopRepository
    {
        private readonly TransporteContext _context;

        public BusStopRepository(TransporteContext context)
        {
            _context = context;
        }

        public BusStop Create(BusStop model)
        {
            _context.BusStops.Add(model);
            _context.SaveChanges();
            return model;
        }

        public void DeleteById(long id)
        {
            var result = _context.BusStops.Find(id);
            if (result != null)
            {
                _context.BusStops.Remove(result);
                _context.SaveChanges();
            }
        }

        public bool ExistsById(long id)
        {
            return _context.BusStops.Any(x => x.Id == id);
        }

        public ICollection<BusStop> FindAll()
        {
            return _context.BusStops.AsNoTracking().ToList();
        }

        public BusStop? FindById(long id)
        {
            return _context.BusStops.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public BusStop Update(BusStop model)
        {
            _context.BusStops.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
