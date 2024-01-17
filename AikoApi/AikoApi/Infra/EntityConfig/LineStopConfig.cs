using AikoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AikoApi.Infra.EntityConfig
{
	public class LineStopConfig : IEntityTypeConfiguration<LineStop>
	{
		public void Configure(EntityTypeBuilder<LineStop> builder)
		{			
			builder.HasOne(lineStop => lineStop.Line)
					.WithMany(line => line.LineStops)
					.HasForeignKey(lineStop => lineStop.LineId)
					.OnDelete(DeleteBehavior.Cascade); 

			builder.HasOne(lineStop => lineStop.Stop)
					.WithMany(stop => stop.LineStops)
					.HasForeignKey(lineStop => lineStop.StopId)
					.OnDelete(DeleteBehavior.Cascade);  

		}
	}
}
