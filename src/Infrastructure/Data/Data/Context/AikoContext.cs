using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.DataContext;

namespace Data.Context
{
    public class AikoContext : DbContext, IDataContext
    {
        public AikoContext(DbContextOptions<AikoContext> options) : base(options) {  }

        public DbSet<Line> Line {  get; set; }
        public DbSet<Stop> Stop {  get; set; }
        public DbSet<Vehicle> Vehicle {  get; set; }
        public DbSet<VehiclePosition> VehiclePosition  {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
