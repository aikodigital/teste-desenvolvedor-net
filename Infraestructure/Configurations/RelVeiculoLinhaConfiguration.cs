using Domain.Models;
using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RelVeiculoLinhaConfiguration : IEntityTypeConfiguration<RelVeiculoLinha>
    {
        public void Configure(EntityTypeBuilder<RelVeiculoLinha> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");
            builder.Property(e => e.IdLinha).HasColumnName("id_linha");
            builder.Property(e => e.DataInicio).HasColumnName("data_inicio");
            builder.Property(e => e.DataFim).HasColumnName("data_fim");

            builder.HasOne(e => e.Veiculo)
                    .WithOne()
                    .HasForeignKey<RelVeiculoLinha>(e => e.IdVeiculo);

            builder.HasOne(e => e.Linha)
                    .WithOne()
                    .HasForeignKey<RelVeiculoLinha>(e => e.IdLinha);

            builder.ToTable("rel_veiculo_linha", EEsquemaBanco.olho_vivo.ToString());
        }
    }
}
