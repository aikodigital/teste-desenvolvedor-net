using Aiko.OlhoVivo.Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiko.OlhoVivo.Persistence.Mapping;

public class VehicleMap : BaseEntityMap<Vehicle>
{
    public override void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicle");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Name)
             .IsRequired()
             .HasMaxLength(100)
             .IsUnicode(false);

        builder.Property(e => e.Modelo)
             .IsRequired()
             .HasMaxLength(50)
             .IsUnicode(false);

        builder.HasOne(d => d.Line)
            .WithMany()
            .HasForeignKey(d => d.LineId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Vehicle_Line");

        builder
            .HasIndex(e => e.LineId)
            .HasDatabaseName("IX_Vehicle_LineId");

        base.Configure(builder);
    }
}
