using AikoDigital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AikoDigital.DataContext.EntityConfigMap
{
    public class LinhaParadaMap : IEntityTypeConfiguration<LinhaParada>
    {
        public void Configure(EntityTypeBuilder<LinhaParada> builder)
        {
            builder.HasKey(lp => new {lp.LinhaId , lp.ParadaId});        
        }
    }
}
