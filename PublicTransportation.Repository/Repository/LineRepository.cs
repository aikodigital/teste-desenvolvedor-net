using Microsoft.EntityFrameworkCore;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Domain.Interfaces.Repositories;
using PublicTransportation.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportation.Infra.Repository
{
    public class LineRepository : BaseRepository<Line>, ILineRepository
    {
        private readonly DbSet<LineStop> _dbLineStop;

        public LineRepository(ApiDbContext apiDbContext) : base(apiDbContext) 
            => _dbLineStop = apiDbContext.Set<LineStop>();
        

        public override Line GetById(long id)
            => _db.Include(x => x.Vehicles).ThenInclude(x => x.Position)
                  .Include(x => x.LinesStops).ThenInclude(x => x.Stop)
                  .FirstOrDefault(x => x.Id == id);

        public Line GetByIdWithVehicles(long id)
            => _db.Include(x => x.Vehicles).ThenInclude(x => x.Position)
                  .FirstOrDefault(x => x.Id == id);

        public LineStop GetLineStopByLineIdStopId(long lineId, long stopId)
            => _dbLineStop.FirstOrDefault(x => x.LineId == lineId && x.StopId == stopId);
        

        public ICollection<LineStop> GetAllLineStopByLineId(long lineId)
            => _dbLineStop.Include(x => x.Stop).Where(x => x.LineId == lineId).ToList();

        public void AddRangeLineStops(ICollection<LineStop> lineStops)
            => _dbLineStop.AddRange(lineStops);
        public void RemoveLineStop(LineStop lineStop)
            => _dbLineStop.Remove(lineStop);
        
        public void RemoveRangeLineStop(ICollection<LineStop> lineStops)
            => _dbLineStop.RemoveRange(lineStops);

        
    }
}
