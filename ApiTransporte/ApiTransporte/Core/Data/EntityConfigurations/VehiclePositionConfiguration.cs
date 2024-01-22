using ApiTransporte.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTransporte.Core.Data.EntityConfigurations
{
    public class VehiclePositionConfiguration : IEntityTypeConfiguration<VehiclePosition>
    {
        public void Configure(EntityTypeBuilder<VehiclePosition> builder)
        {
            builder.ToTable("VehiclePosition");

            builder.HasKey(vp => vp.Id);

            builder.Property(vp => vp.Latitude)
                .IsRequired();

            builder.Property(vp => vp.Longitude)
                .IsRequired();
            
        }
    }
}
