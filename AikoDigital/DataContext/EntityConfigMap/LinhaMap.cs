using AikoDigital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AikoDigital.DataContext.EntityConfigMap
{
    public class LinhaMap : IEntityTypeConfiguration<Linha>
    {
        public void Configure(EntityTypeBuilder<Linha> builder) {
            builder.HasKey(x => x.Id);
        }
    }
}
