using Aiko.OlhoVivo.Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.OlhoVivo.Persistence.Mapping;

public class StopMap : BaseEntityMap<Stop>
{
    public override void Configure(EntityTypeBuilder<Stop> builder)
    {
        builder.ToTable("Stop");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Name)
             .IsRequired()
             .HasMaxLength(100)
             .IsUnicode(false);

        builder.Property(e => e.Latitude)
            .HasMaxLength(150)
            .HasDefaultValue(0.0)
            .IsUnicode(false);

        builder.Property(e => e.Longitude)
            .HasMaxLength(150)
            .HasDefaultValue(0.0)
            .IsUnicode(false);

        base.Configure(builder);
    }
}