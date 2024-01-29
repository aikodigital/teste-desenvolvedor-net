using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Infra.Data.EntitiesConfiguration;

public class VehiclePositionConfiguration : IEntityTypeConfiguration<VehiclePosition>
{
    public void Configure(EntityTypeBuilder<VehiclePosition> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Latitude).HasPrecision(20,10).IsRequired();
        builder.Property(p => p.Longitude).HasPrecision(20,10).IsRequired();

        builder.HasOne(e => e.Vehicle)
               .WithOne(e => e.VehiclePosition)
               .HasForeignKey<VehiclePosition>(e => e.VehicleId);
    }
}
