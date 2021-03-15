using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class LinhaConfiguration : IEntityTypeConfiguration<Linha>
    {
        public void Configure(EntityTypeBuilder<Linha> builder)
        {
            builder.Property(x => x.Nome).IsRequired();

            builder
                .HasMany(p => p.Paradas)
                .WithMany(p => p.Linhas)
                .UsingEntity<Dictionary<string, object>>(
                    "LinhasPorParada",
                    j => j
                        .HasOne<Parada>()
                        .WithMany()
                        .HasForeignKey("ParadaId")
                        .HasConstraintName("FK_LinhaParada_Paradas_ParadaId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Linha>()
                        .WithMany()
                        .HasForeignKey("LinhaId")
                        .HasConstraintName("FK_LinhaParada_Linhas_LinhaId")
                        .OnDelete(DeleteBehavior.ClientCascade));
        }
    }
}