using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicTransportation.Models;

namespace PublicTransportation.Infra.Mapping
{
    public class LineMap : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name);

            builder.HasMany(x => x.LinesStops)
                   .WithOne(x => x.Line)
                   .HasForeignKey(x => x.LineId);

        }
    }
}
