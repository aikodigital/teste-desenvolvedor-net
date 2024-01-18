using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportePublico.Domain.Entity.PosicoesVeiculos;

namespace TransportePublico.Data.Configurations
{
    public class PosicaoVeiculoConfiguration : IEntityTypeConfiguration<PosicaoVeiculo>
    {
        public void Configure(EntityTypeBuilder<PosicaoVeiculo> builder)
        {
            builder.ToTable("PosicoesVeiculos");

            builder.HasKey(p => p.PosicaoVeiculoId);

            builder.Property(p => p.PosicaoVeiculoId)
                .HasColumnName("PosicaoVeiculoid")
                .IsRequired();

            builder.Property(p => p.Latitude)
                .HasColumnName("Latitude")
                .IsRequired();

            builder.Property(p => p.Longitude)
                .HasColumnName("Longitude")
                .IsRequired();

            builder.HasOne(p => p.Veiculo)
                .WithMany()
                .HasForeignKey(p => p.VeiculoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
