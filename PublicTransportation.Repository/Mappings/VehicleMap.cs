using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicTransportation.Models;

namespace PublicTransportation.Infra.Mappings
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name);

            builder.Property(x => x.Model);

            builder.HasOne(x => x.Line)
                   .WithMany(x => x.Vehicles)
                   .HasForeignKey(x => x.LineId);
        }
    }
}
