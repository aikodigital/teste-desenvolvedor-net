using PublicTransportation.Infra.Context;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Domain.Interfaces.Repositories;

namespace PublicTransportation.Infra.Repository
{
    public class StopRepository : BaseRepository<Stop>, IStopRepository
    {
        public StopRepository(ApiDbContext apiDbContext) : base(apiDbContext) { }
    }
}
