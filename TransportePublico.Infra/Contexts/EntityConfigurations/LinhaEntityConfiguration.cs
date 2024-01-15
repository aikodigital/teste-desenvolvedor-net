using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportePublico.Domain.Entity.Linhas;

namespace TransportePublico.Infra.Contexts.EntityConfigurations
{
    public class LinhaEntityConfiguration : IEntityTypeConfiguration<Linha>
    {
        public void Configure(EntityTypeBuilder<Linha> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .HasColumnType("varchar(255)");

            builder.HasMany(l => l.Paradas)
                .WithOne(p => p.Linha)
                .HasForeignKey(p => p.LinhaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(l => l.Veiculos)
                .WithOne(v => v.Linha)
                .HasForeignKey(v => v.LinhaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Linhas");
        }
    }
}
