using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Modelo).IsRequired();
            builder.Property(x => x.Nome).IsRequired();

            builder.OwnsOne(x => x.Localizacao, y => {
                y.Property(x => x.Latitude).HasColumnName(nameof(Localizacao.Latitude)).IsRequired();
                y.Property(x => x.Longitude).HasColumnName(nameof(Localizacao.Longitude)).IsRequired();
            });
        }
    }
}