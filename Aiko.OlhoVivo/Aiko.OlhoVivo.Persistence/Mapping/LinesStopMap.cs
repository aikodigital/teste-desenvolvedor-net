using Aiko.OlhoVivo.Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.OlhoVivo.Persistence.Mapping;

public class LinesStopMap : BaseEntityMap<LineStop>
{
    public override void Configure(EntityTypeBuilder<LineStop> builder)
    {
        builder.ToTable("LineStop");

        builder.HasKey(x => x.Id);

        builder.HasOne(d => d.Stop)
            .WithMany()
            .HasForeignKey(d => d.StopId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_LineStop_Stop");

        builder.HasOne(d => d.Line)
            .WithMany()
            .HasForeignKey(d => d.LineId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_LineStop_Line");

        builder
            .HasIndex(e => e.StopId)
            .HasDatabaseName("IX_LineStop_StopId");

        builder
            .HasIndex(e => e.LineId)
            .HasDatabaseName("IX_LineStop_LineId");

        base.Configure(builder);
    }
}
