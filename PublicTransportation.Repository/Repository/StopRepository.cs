using PublicTransportation.Infra.Context;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PublicTransportation.Infra.Repository
{
    public class StopRepository : BaseRepository<Stop>, IStopRepository
    {
        private readonly DbSet<LineStop> _dbLineStop;

        public StopRepository(ApiDbContext apiDbContext) : base(apiDbContext) 
            => _dbLineStop = apiDbContext.Set<LineStop>();
        
        public ICollection<LineStop> GetAllLineStopByStopId(long stopId)
            => _dbLineStop.Include(x => x.Line).Where(x => x.StopId == stopId).ToList();

        public Stop GetByIdWithLines(long id)
            => _db.Include(x => x.LinesStops).ThenInclude(x => x.Line).FirstOrDefault(x => x.Id == id);

        public void RemoveRangeLineStop(ICollection<LineStop> lineStops)
            => _dbLineStop.RemoveRange(lineStops);
    }
}
