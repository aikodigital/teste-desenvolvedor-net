using ApiTransporte.Core.Data.EntityConfigurations;
using ApiTransporte.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTransporte.Core.Data.Contexts
{
    public class TransporteContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TransporteContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<BusStop>? BusStops { get; set; }
        public DbSet<Line>? Lines { get; set; }
        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<VehiclePosition>? VehiclePositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("APITransporte"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusStopConfiguration());
            modelBuilder.ApplyConfiguration(new LineConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new VehiclePositionConfiguration());
        }
    }
}
