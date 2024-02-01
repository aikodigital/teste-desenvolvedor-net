using Aiko.OlhoVivo.Infrastructure.Useful;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.OlhoVivo.Persistence.Mapping;

public class BaseEntityMap<TEntidade> : IEntityTypeConfiguration<TEntidade>
    where TEntidade : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntidade> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(e => e.DataAlteracao)
            .HasColumnType ("datetime");

        builder
            .Property(e => e.DataCadastro)
            .HasColumnType("datetime");

        builder
            .Property(e => e.DataExclusao)
            .HasColumnType("datetime");
    }
}
