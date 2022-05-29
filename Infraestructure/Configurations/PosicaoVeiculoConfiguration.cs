using Domain.Models;
using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PosicaoVeiculoConfiguration : IEntityTypeConfiguration<PosicaoVeiculo>
    {
        public void Configure(EntityTypeBuilder<PosicaoVeiculo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdVeiculo).HasColumnName("id_veiculo");
            builder.Property(e => e.Latitude).HasColumnName("latitude");
            builder.Property(e => e.Longitude).HasColumnName("longitude");
            builder.Property(e => e.DataPosicao).HasColumnName("data_posicao");

            builder.HasOne(e => e.Veiculo)
                    .WithOne()
                    .HasForeignKey<PosicaoVeiculo>(e => e.IdVeiculo);

            builder.ToTable("posicao_veiculo", EEsquemaBanco.olho_vivo.ToString());
        }
    }
}
