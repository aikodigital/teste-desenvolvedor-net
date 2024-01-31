using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Domain.Interfaces.Repositories
{
    public interface ILineRepository : IRepository<Line>
    {
        public Line GetByIdWithVehicles(long id);
        public LineStop GetLineStopByLineIdStopId(long lineId, long stopId);
        public ICollection<LineStop> GetAllLineStopByLineId(long lineId);
        public void AddRangeLineStops(ICollection<LineStop> lineStops);
        public void RemoveLineStop(LineStop lineStop);
        public void RemoveRangeLineStop(ICollection<LineStop> lineStops);
    }
}
