using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportePublico.Domain.Entity.PosicoesVeiculos;

namespace TransportePublico.Infra.Contexts.EntityConfigurations
{
    public class PosicaoVeiculoEntityConfiguration : IEntityTypeConfiguration<PosicaoVeiculo>
    {
        public void Configure(EntityTypeBuilder<PosicaoVeiculo> builder)
        {
            builder.HasKey(p => p.PosicaoVeiculoId);

            builder.Property(p => p.Latitude)
                .HasColumnType("decimal(10, 6)");

            builder.Property(p => p.Longitude)
                .HasColumnType("decimal(10, 6)");

            builder.HasOne(p => p.Veiculo)
                .WithOne(v => v.PosicaoVeiculo)
                .HasForeignKey<PosicaoVeiculo>(p => p.VeiculoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("PosicoesVeiculos");
        }
    }
}
