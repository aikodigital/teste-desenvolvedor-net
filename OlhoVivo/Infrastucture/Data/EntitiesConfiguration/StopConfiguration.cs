using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Infra.Data.EntitiesConfiguration;

public class StopConfiguration : IEntityTypeConfiguration<Stop>
{
    public void Configure(EntityTypeBuilder<Stop> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Latitude).HasPrecision(20,10).IsRequired();
        builder.Property(p => p.Longitude).HasPrecision(20,10).IsRequired();

        builder.HasOne(e => e.Line)
               .WithMany(e => e.Stops)
               .HasForeignKey(e => e.LineId);
    }
}
