using AikoDigital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AikoDigital.DataContext.EntityConfigMap
{
    public class PosicaoVeiculoMap : IEntityTypeConfiguration<PosicaoVeiculo>
    {
        public void Configure(EntityTypeBuilder<PosicaoVeiculo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
