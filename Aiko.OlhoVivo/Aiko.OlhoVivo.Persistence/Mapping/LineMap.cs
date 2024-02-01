using Aiko.OlhoVivo.Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.OlhoVivo.Persistence.Mapping;

public class LineMap : BaseEntityMap<Line>
{
    public override void Configure(EntityTypeBuilder<Line> builder)
    {
        builder.ToTable("Line");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Name)
             .IsRequired()
             .HasMaxLength(100)
             .IsUnicode(false);

        base.Configure(builder);
    }
}
