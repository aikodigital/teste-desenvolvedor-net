using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportePublico.Domain.Entity.Veiculos;

namespace TransportePublico.Data.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculos");

            builder.HasKey(v => v.VeiculoId);

            builder.Property(v => v.VeiculoId)
                .HasColumnName("VeiculoId")
                .IsRequired();

            builder.Property(v => v.Name)
                .HasColumnName("Name")
                .HasMaxLength(255); 

            builder.Property(v => v.Modelo)
                .HasColumnName("Modelo")
                .HasMaxLength(255); 

            builder.HasOne(v => v.Linha)
                .WithMany()
                .HasForeignKey(v => v.LinhaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
