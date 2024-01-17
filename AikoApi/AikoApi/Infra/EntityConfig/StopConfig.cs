using AikoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AikoApi.Infra.EntityConfig
{
	public class StopConfig : IEntityTypeConfiguration<Stop>
	{
		public void Configure(EntityTypeBuilder<Stop> builder)
		{
			builder.HasMany(stop => stop.LineStops)
					.WithOne(lineStop => lineStop.Stop)
					.HasForeignKey(lineStop => lineStop.StopId);
		}
	}
}
