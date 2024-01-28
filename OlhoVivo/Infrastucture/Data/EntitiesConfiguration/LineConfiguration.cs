using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Infra.Data.EntitiesConfiguration;

public class LineConfiguration : IEntityTypeConfiguration<Line>
{
    public void Configure(EntityTypeBuilder<Line> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        builder.HasData(
            new Line(1, "SOL NASCENTE / TERM. PIRITUBA"),
            new Line(2, "TERM. LAPA / PÇA. RAMOS DE AZEVEDO"),
            new Line(3, "TERM. PQ. D. PEDRO II / TERM. BANDEIRA")
        );
    }
}
