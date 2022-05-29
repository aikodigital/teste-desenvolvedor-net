using Domain.Models;
using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Nome).HasColumnName("nome");
            builder.Property(e => e.Modelo).HasColumnName("modelo");
            builder.Property(e => e.Ativo).HasColumnName("ativo");

            builder.ToTable("veiculo", EEsquemaBanco.olho_vivo.ToString());
        }
    }
}
