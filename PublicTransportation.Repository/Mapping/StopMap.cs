using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicTransportation.Models;

namespace PublicTransportation.Infra.Mapping
{
    public class StopMap : IEntityTypeConfiguration<Stop>
    {
        public void Configure(EntityTypeBuilder<Stop> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name);

            builder.Property(x => x.Latitude);

            builder.Property(x => x.Longitude);

            builder.HasMany(x => x.LinesStops)
                   .WithOne(x => x.Stop)
                   .HasForeignKey(x => x.StopId);
        }
    }
}
