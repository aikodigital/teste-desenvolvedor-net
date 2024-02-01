using Aiko.OlhoVivo.Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.OlhoVivo.Persistence.Mapping;

public class VehiclePositionMap : BaseEntityMap<VehiclePosition>
{
    public override void Configure(EntityTypeBuilder<VehiclePosition> builder)
    {
        builder.ToTable("VehiclePosition");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Latitude)
            .HasMaxLength(150)
            .HasDefaultValue(0.0)
            .IsUnicode(false);

        builder.Property(e => e.Longitude)
            .HasMaxLength(150)
            .HasDefaultValue(0.0)
            .IsUnicode(false);

        builder.HasOne(d => d.Vehicle)
            .WithMany()
            .HasForeignKey(d => d.VehicleId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_VehiclePosition_Vehicle");

        builder
            .HasIndex(e => e.VehicleId)
            .HasDatabaseName("IX_VehiclePosition_VehicleId");

        base.Configure(builder);
    }
}