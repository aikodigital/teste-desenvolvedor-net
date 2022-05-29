using Domain.Models;
using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ParadaConfiguration : IEntityTypeConfiguration<Parada>
    {
        public void Configure(EntityTypeBuilder<Parada> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Nome).HasColumnName("nome");
            builder.Property(e => e.Latitude).HasColumnName("latitude");
            builder.Property(e => e.Longitude).HasColumnName("longitude");
            builder.Property(e => e.Ativo).HasColumnName("ativo");

            builder.ToTable("parada", EEsquemaBanco.olho_vivo.ToString());
        }
    }
}
