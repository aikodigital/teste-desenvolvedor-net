using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportePublico.Domain.Entity.LinhasParadas;

namespace TransportePublico.Data.Configurations
{
    public class LinhaParadaConfiguration : IEntityTypeConfiguration<LinhaParada>
    {
        public void Configure(EntityTypeBuilder<LinhaParada> builder)
        {
            builder.ToTable("LinhasParadas");
            builder.HasKey(p => p.LinhaParadaId);
            builder.Property(p => p.LinhaId);
            builder.Property(p => p.ParadaId);
            builder.HasOne(p => p.Linha)
                .WithMany(l => l.LinhasParadas)
                .HasForeignKey(p => p.LinhaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Parada)
                .WithMany(p => p.LinhasParadas)
                .HasForeignKey(p => p.ParadaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
