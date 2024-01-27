using PublicTransportation.Infra.Context;
using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Infra.Repository
{
    public class StopRepository : BaseRepository<Stop>
    {
        public StopRepository(ApiDbContext apiDbContext) : base(apiDbContext) { }
    }
}
