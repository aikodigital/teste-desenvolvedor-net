using Microsoft.EntityFrameworkCore;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Domain.Interfaces.Repositories;
using PublicTransportation.Infra.Context;
using System.Linq;

namespace PublicTransportation.Infra.Repository
{
    public class LineRepository : BaseRepository<Line>, ILineRepository
    {
        public LineRepository(ApiDbContext apiDbContext) : base(apiDbContext) { }

        public override Line GetById(long id)
        {
            return _db.Include(x => x.Vehicles).ThenInclude(x => x.Position)
               .Include(x => x.LinesStops).ThenInclude(x => x.Stop)
               .FirstOrDefault(x => x.Id == id);
        }
    }
}
