using Microsoft.EntityFrameworkCore;
using PublicTransportation.Infra.Seed;
using PublicTransportation.Models;

namespace PublicTransportation.Infrastructure.Seed
{
    public class SeedConfig
    {
        public void ApplySeeds(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Line>().HasData(new LineSeed().Seeds);
            modelBuilder.Entity<Stop>().HasData(new StopSeed().Seeds);
            modelBuilder.Entity<LineStop>().HasData(new LineStopSeed().Seeds);
            modelBuilder.Entity<Vehicle>().HasData(new VehicleSeed().Seeds);
            modelBuilder.Entity<VehiclePosition>().HasData(new VehiclePositionSeed().Seeds);
        }
    }
}
