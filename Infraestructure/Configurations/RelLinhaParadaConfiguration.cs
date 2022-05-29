using Domain.Models;
using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RelLinhaParadaConfiguration : IEntityTypeConfiguration<RelLinhaParada>
    {
        public void Configure(EntityTypeBuilder<RelLinhaParada> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdLinha).HasColumnName("id_linha");
            builder.Property(e => e.IdParada).HasColumnName("id_parada");

            builder.HasOne(e => e.Parada)
                    .WithOne()
                    .HasForeignKey<RelLinhaParada>(e => e.IdParada);

            builder.HasOne(e => e.Linha)
                    .WithOne()
                    .HasForeignKey<RelLinhaParada>(e => e.IdLinha);

            builder.ToTable("rel_linha_parada", EEsquemaBanco.olho_vivo.ToString());
        }
    }
}
