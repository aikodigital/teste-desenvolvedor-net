using AikoApi.Infra.EntityConfig;
using AikoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AikoApi.Infra.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Line> Lines { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePosition> VehiclePositions { get; set; }
        public DbSet<LineStop> LinesStops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LineConfig());
            modelBuilder.ApplyConfiguration(new StopConfig());
            modelBuilder.ApplyConfiguration(new VehicleConfig());
            modelBuilder.ApplyConfiguration(new VehiclePositionConfig());
            modelBuilder.ApplyConfiguration(new LineStopConfig());
        }
    }
}

