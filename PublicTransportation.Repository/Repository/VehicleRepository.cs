using PublicTransportation.Domain.Entities;
using PublicTransportation.Infra.Context;

namespace PublicTransportation.Infra.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle>
    {
        public VehicleRepository(ApiDbContext apiDbContext) : base(apiDbContext) { }
    }
}
