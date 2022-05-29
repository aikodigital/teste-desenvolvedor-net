using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Repositories
{
    public class EFApplicationContext : DbContext
    {
        public static Assembly ConfigurationsAssembly { get; set; }

        public EFApplicationContext() : base()
        {
        }

        public EFApplicationContext(DbContextOptions<EFApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFApplicationContext).Assembly);
        }
    }
}
