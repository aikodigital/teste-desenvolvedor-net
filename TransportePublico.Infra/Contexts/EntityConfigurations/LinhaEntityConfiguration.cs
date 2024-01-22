using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportePublico.Domain.Entity.Linhas;
using TransportePublico.Domain.Entity.LinhasParadas;

namespace TransportePublico.Data.Configurations
{
    public class LinhaConfiguration : IEntityTypeConfiguration<Linha>
    {
        public void Configure(EntityTypeBuilder<Linha> builder)
        {
            builder.ToTable("Linhas");
            builder.HasKey(x => x.LinhaId);
            builder.Property(x => x.LinhaId).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasMany(x => x.LinhasParadas).WithOne(x => x.Linha).HasForeignKey(x => x.LinhaId);
        }
    }
}
