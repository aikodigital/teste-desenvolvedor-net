using AikoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AikoApi.Infra.EntityConfig
{
	public class LineConfig : IEntityTypeConfiguration<Line>
	{
		public void Configure(EntityTypeBuilder<Line> builder)
		{
			builder.HasMany(line => line.LineStops)
					.WithOne(lineStop => lineStop.Line)
					.HasForeignKey(lineStop => lineStop.LineId);

		}
	}
}
