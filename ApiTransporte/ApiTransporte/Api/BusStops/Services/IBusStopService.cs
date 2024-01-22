using ApiTransporte.Core.Models;

namespace ApiTransporte.Api.BusStops.Services
{
    public interface IBusStopService
    {
        ICollection<BusStop> FindAll();
        BusStop FindById(long id);
        BusStop Create(BusStop busStop);
        BusStop UpdateById(long id, BusStop  busStop);
        void DeleteById(long id);
    }
}
