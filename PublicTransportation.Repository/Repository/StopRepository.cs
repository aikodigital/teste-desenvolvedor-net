using PublicTransportation.Infra.Context;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

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


        public ICollection<Stop> GetClosestStops(double latitude, double longitude)
        {
            return _db.OrderBy(p => Math.Acos(
                Math.Sin(latitude * Math.PI / 180) * Math.Sin(p.Latitude * Math.PI / 180) +
                Math.Cos(latitude * Math.PI / 180) * Math.Cos(p.Latitude * Math.PI / 180) *
                Math.Cos((longitude - p.Longitude) * Math.PI / 180)
            ) * 6371) // Planet radius in km
            .Take(5).ToList();
        }
    }
}
