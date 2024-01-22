using ApiTransporte.Core.Data.Contexts;
using ApiTransporte.Core.Exceptions;
using ApiTransporte.Core.Models;
using ApiTransporte.Core.Repositories.BusStops;

namespace ApiTransporte.Api.BusStops.Services
{
    public class BusStopService : IBusStopService
    {
        private readonly IBusStopRepository _busStopRepository;
        private readonly TransporteContext _context;

        public BusStopService(IBusStopRepository busStopRepository, TransporteContext context)
        {
            _busStopRepository = busStopRepository;
            _context = context;
        }

        public BusStop Create(BusStop busStop)
        {
            return _busStopRepository.Create(busStop);
        }

        public void DeleteById(long id)
        {
            if (!_busStopRepository.ExistsById(id))
            {
                throw new CustomNotFoundException($"BusStop with id {id} not found");
            }
            _busStopRepository.DeleteById(id);
        }

        public ICollection<BusStop> FindAll()
        {
            return _busStopRepository.FindAll();
        }

        public BusStop FindById(long id)
        {
            var result = _busStopRepository.FindById(id);
            if (result is null)
            {
                throw new CustomNotFoundException($"BusStop with id {id} not found");
            }
            return result;
        }

        public BusStop UpdateById(long id, BusStop busStop)
        {
            if (!_busStopRepository.ExistsById(id))
            {
                throw new CustomNotFoundException($"BusStop with id {id} not found");
            }
            busStop.Id = id;
            var updateBusStop = _busStopRepository.Update(busStop);
            return updateBusStop;
        }
    }
}
