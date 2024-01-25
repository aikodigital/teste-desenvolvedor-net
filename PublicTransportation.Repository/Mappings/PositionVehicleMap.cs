using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicTransportation.Models;

namespace PublicTransportation.Infra.Mappings
{
    public class VehiclePositionMap : IEntityTypeConfiguration<VehiclePosition>
    {
        public void Configure(EntityTypeBuilder<VehiclePosition> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Latitude);
            builder.Property(x => x.Longitude);
        }
    }
}
