using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Infra.Data.Identity;

namespace OlhoVivo.Infra.Data.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    #region Properties
    public DbSet<Line> Lines { get; set; }
    public DbSet<Stop> Stops { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehiclePosition> VehiclesPositions { get; set; }
    #endregion

    #region Constructor
    public ApplicationDbContext(){ }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
    #endregion

    #region Methods

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=localhost; Database=OlhoVivoDB; User Id=sa; Password=sql@2019; TrustServerCertificate=True;";

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }        
    }
    #endregion
}
