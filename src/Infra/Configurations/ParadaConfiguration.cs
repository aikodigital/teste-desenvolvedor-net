﻿using Core.Entities;
using Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class ParadaConfiguration : IEntityTypeConfiguration<Parada>
    {
        public void Configure(EntityTypeBuilder<Parada> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.OwnsOne(x => x.Localizacao, y => {
                y.Property(x => x.Latitude).HasColumnName(nameof(Localizacao.Latitude)).IsRequired();
                y.Property(x => x.Longitude).HasColumnName(nameof(Localizacao.Longitude)).IsRequired();
            });
        }
    }
}