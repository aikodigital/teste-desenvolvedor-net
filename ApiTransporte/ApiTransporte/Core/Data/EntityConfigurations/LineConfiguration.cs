using ApiTransporte.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTransporte.Core.Data.EntityConfigurations
{
    public class LineConfiguration : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.ToTable("Lines");

            builder.HasKey(l => l.Id);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(l => l.Vehicles)
            .WithOne(v => v.Line)
            .HasForeignKey(v => v.LineId)
            .IsRequired();
        }
    }
}
