using SharedKernel.Infrastructure.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Vehicle")]
    public class Vehicle : EntityBase
    {
        public Vehicle() 
        {
            VehiclePosition = new HashSet<VehiclePosition>();
        }

        [ForeignKey("Line")]
        public long LineId { get; set; }

        [StringLength(50, ErrorMessage = "Allowable field size (50)")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Allowable field size (10)")]
        public string Model { get; set; }

        public Line Line { get; set; }

        public virtual ICollection<VehiclePosition> VehiclePosition { get; set; }
    }
}
