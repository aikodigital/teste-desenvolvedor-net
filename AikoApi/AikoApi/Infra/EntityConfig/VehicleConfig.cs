using AikoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AikoApi.Infra.EntityConfig
{
	public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
	{
		public void Configure(EntityTypeBuilder<Vehicle> builder)
		{
			builder.HasOne<Line>()
					.WithMany()
					.HasForeignKey(v => v.LineId);
		}
	}
}
