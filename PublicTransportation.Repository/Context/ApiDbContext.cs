using Microsoft.EntityFrameworkCore;
using PublicTransportation.Infra.Configuration;
using PublicTransportation.Infra.Mappings;
using PublicTransportation.Infrastructure.Seed;
using System;

namespace PublicTransportation.Infra.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {

        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(AppConfiguration.GetDatabaseConfig().ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LineMap());
            modelBuilder.ApplyConfiguration(new StopMap());
            modelBuilder.ApplyConfiguration(new VehicleMap());
            modelBuilder.ApplyConfiguration(new VehiclePositionMap());

            new SeedConfig().ApplySeeds(modelBuilder);
        }
    }
}
