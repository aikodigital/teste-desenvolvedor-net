using ApiTransporte.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTransporte.Core.Data.EntityConfigurations
{
    public class BusStopConfiguration : IEntityTypeConfiguration<BusStop>
    {
        public void Configure(EntityTypeBuilder<BusStop> builder)
        {
            builder.ToTable("BusStops");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Latitude)
                .IsRequired();

            builder.Property(b => b.Longitude)
               .IsRequired();
        }
    }
}
