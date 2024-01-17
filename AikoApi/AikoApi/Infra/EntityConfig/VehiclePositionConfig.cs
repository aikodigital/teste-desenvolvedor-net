using AikoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AikoApi.Infra.EntityConfig
{
	public class VehiclePositionConfig : IEntityTypeConfiguration<VehiclePosition>
	{
		public void Configure(EntityTypeBuilder<VehiclePosition> builder)
		{
			builder.HasOne<Vehicle>()
						.WithMany()
						.HasForeignKey(vl => vl.VehicleId);
		}
	}
}
