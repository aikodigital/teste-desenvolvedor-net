using ApiTransporte.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTransporte.Core.Data.EntityConfigurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(v => v.Model)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(v => v.Line)
           .WithMany(l => l.Vehicles)
           .HasForeignKey(v => v.LineId)
           .IsRequired();
        }
    }
}
