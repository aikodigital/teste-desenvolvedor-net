using Microsoft.EntityFrameworkCore;
using PublicTransport.API.Entities;

namespace PublicTransport.API.Persistence
{
    public class PublicTransportDbContext : DbContext
    {
        public PublicTransportDbContext(DbContextOptions<PublicTransportDbContext> options) : base(options)
        {

        }

        public DbSet<Line> Lines { get; set; }

        public DbSet<Stop> Stops { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehiclePosition> VehiclePositions { get; set; }

        public DbSet<LineStop> LineStops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Line>(e =>
            {
                e.HasKey(l => l.LineId);

                e.Property(l => l.LineId).ValueGeneratedOnAdd();

                e.Property(l => l.Name).IsRequired();

                e.HasMany(l => l.LineStops)
                    .WithOne(ls => ls.Line)
                    .HasForeignKey(ls => ls.LineId);
            });

            modelBuilder.Entity<LineStop>(e =>
            {
                e.HasKey(ls => ls.LineStopId);

                e.Property(ls => ls.LineId);
                e.Property(ls => ls.StopId);

                e.HasOne(ls => ls.Line)
                    .WithMany(ls => ls.LineStops)
                    .HasForeignKey(ls => ls.LineId);
                e.HasOne(ls => ls.Stop)
                    .WithMany(ls => ls.LineStops)
                    .HasForeignKey(ls => ls.StopId);
            });

            modelBuilder.Entity<Stop>(e =>
            {
                e.HasKey(s => s.StopId);
                e.Property(s => s.StopId).ValueGeneratedOnAdd();
                e.Property(s => s.Name).IsRequired();
                e.Property(s => s.Latitude).IsRequired();
                e.Property(s => s.Longitude).IsRequired();
                e.HasMany(s => s.LineStops)
                    .WithOne(ls => ls.Stop)
                    .HasForeignKey(ls => ls.StopId);
            });

            modelBuilder.Entity<Vehicle>(e =>
            {
                e.HasKey(v => v.VehicleId);

                e.Property(v => v.VehicleId).ValueGeneratedOnAdd();

                e.Property(v => v.Name).IsRequired();

                e.Property(v => v.Model).IsRequired();

                e.HasOne(v => v.Line)
                    .WithMany()
                    .HasForeignKey(v => v.LineId);
            });

            modelBuilder.Entity<VehiclePosition>(e =>
            {
                e.HasKey(vp => vp.VehiclePositionId);

                e.Property(vp => vp.VehiclePositionId).ValueGeneratedOnAdd();

                e.Property(vp => vp.Latitude).IsRequired();

                e.Property(vp => vp.Longitude).IsRequired();

                e.HasOne(vp => vp.Vehicle)
                    .WithMany()
                    .HasForeignKey(vp => vp.VehicleId);
            });
        }
    }
}
