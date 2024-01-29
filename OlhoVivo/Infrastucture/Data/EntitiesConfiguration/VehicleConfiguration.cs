using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Infra.Data.EntitiesConfiguration;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Model).HasMaxLength(100).IsRequired();

        builder.HasOne(e => e.Line)
               .WithMany(e => e.Vehicles)
               .HasForeignKey(e => e.LineId);
    }
}
