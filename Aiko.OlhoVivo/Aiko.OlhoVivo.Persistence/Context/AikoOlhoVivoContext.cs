using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using Microsoft.EntityFrameworkCore;

namespace Aiko.OlhoVivo.Persistence.Context;

public class AikoOlhoVivoContext : DbContext
{
    public AikoOlhoVivoContext(DbContextOptions<AikoOlhoVivoContext> options) 
        : base(options) { }


    public DbSet<Line> Line { get; set; }
    public DbSet<Stop> Stop { get; set; }
    public DbSet<Vehicle> Vehicle { get; set; }
    public DbSet<LineStop> LineStop { get; set; }
    public DbSet<VehiclePosition> VehiclePosition { get; set; }
}