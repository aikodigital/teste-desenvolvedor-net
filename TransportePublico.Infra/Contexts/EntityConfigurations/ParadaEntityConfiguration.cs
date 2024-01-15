using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.Infra.Contexts.EntityConfigurations
{
    public class ParadaEntityConfiguration : IEntityTypeConfiguration<Parada>
    {
        public void Configure(EntityTypeBuilder<Parada> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(255)");

            builder.Property(p => p.Latitude)
                .HasColumnType("decimal(10, 6)");

            builder.Property(p => p.Longitude)
                .HasColumnType("decimal(10, 6)");

            builder.HasOne(p => p.Linha)
                .WithMany(l => l.Paradas)
                .HasForeignKey(p => p.LinhaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Paradas");
        }
    }
}
