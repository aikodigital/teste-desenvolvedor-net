using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.Infra.Contexts.EntityConfigurations
{
    public class VeiculoEntityConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Name)
                .HasColumnType("varchar(255)");

            builder.Property(v => v.Modelo)
                .HasColumnType("varchar(255)");

            builder.HasOne(v => v.Linha)
                .WithMany(l => l.Veiculos)
                .HasForeignKey(v => v.LinhaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.PosicaoVeiculo)
                .WithOne(pv => pv.Veiculo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Veiculos");
        }
    }
}
