using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportePublico.Domain.Entity.LinhasParadas;
using TransportePublico.Domain.Entity.Paradas;

namespace TransportePublico.Data.Configurations
{
    public class ParadaConfiguration : IEntityTypeConfiguration<Parada>
    {
        public void Configure(EntityTypeBuilder<Parada> builder)
        {
            builder.ToTable("Paradas");
            builder.HasKey(x => x.ParadaId);
            builder.Property(x => x.ParadaId).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasMany(x => x.Linhas).WithMany(x => x.Paradas).UsingEntity<LinhaParada>(
                x => x.HasOne(x => x.Linha).WithMany(x => x.LinhasParadas).HasForeignKey(x => x.LinhaId),
                x => x.HasOne(x => x.Parada).WithMany(x => x.LinhasParadas).HasForeignKey(x => x.Parada),
                x => x.ToTable("LinhasParadas"));
        }
    }
}
