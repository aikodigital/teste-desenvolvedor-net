using Microsoft.EntityFrameworkCore;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Domain.Interfaces.Repositories;
using PublicTransportation.Infra.Context;
using System.Linq;

namespace PublicTransportation.Infra.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        private readonly DbSet<VehiclePosition> _dbVehiclePosition;

        public VehicleRepository(ApiDbContext apiDbContext) : base(apiDbContext) 
        {
            _dbVehiclePosition = apiDbContext.Set<VehiclePosition>();
        }

        public override IQueryable<Vehicle> ApplyIncludes(IQueryable<Vehicle> query)
            => query.Include(x => x.Line).Include(x => x.Position);
        


        public VehiclePosition GetVehiclePositionByVehicleId(long vehicleId)
            => _dbVehiclePosition.FirstOrDefault(x => x.VehicleId == vehicleId);

        public void CreateVehiclePosition(VehiclePosition vehiclePosition)
            => _dbVehiclePosition.Add(vehiclePosition);
        
        public void UpdateVehiclePosition(VehiclePosition vehiclePosition)
            => _dbVehiclePosition.Update(vehiclePosition);
        
        public void DeleteVehiclePosition(VehiclePosition vehiclePosition)
            =>_dbVehiclePosition.Remove(vehiclePosition);

        public bool VehicleHasPosition(long vehicleId)
            => _dbVehiclePosition.Any(x => x.VehicleId == vehicleId);

    }
}
