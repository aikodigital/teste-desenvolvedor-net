using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Domain.Interfaces.Repositories
{
    public interface IStopRepository : IRepository<Stop>
    {
        public ICollection<LineStop> GetAllLineStopByStopId(long stopId);
        public Stop GetByIdWithLines(long id);
        public void RemoveRangeLineStop(ICollection<LineStop> lineStops);
        public ICollection<Stop> GetClosestStops(double latitude, double longitude);
    }
}
