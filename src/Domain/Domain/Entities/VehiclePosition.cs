using SharedKernel.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("VehiclePosition")]
    public class VehiclePosition : EntityBase
    {
        [ForeignKey("Vehicle")]
        public long VehicleId { get; set; }

        [Column(TypeName = "float(10)")]
        public double Latitude { get; set; }

        [Column(TypeName = "float(10)")]
        public double Longitude { get; set; }
    }
}
