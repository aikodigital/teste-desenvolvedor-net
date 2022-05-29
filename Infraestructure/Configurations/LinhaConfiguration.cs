using Domain.Models;
using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class LinhaConfiguration : IEntityTypeConfiguration<Linha>
    {
        public void Configure(EntityTypeBuilder<Linha> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Nome).HasColumnName("nome");
            builder.Property(e => e.Ativo).HasColumnName("ativo");

            builder.ToTable("linha", EEsquemaBanco.olho_vivo.ToString());
        }
    }
}
