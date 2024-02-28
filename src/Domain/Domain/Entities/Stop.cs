using SharedKernel.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Stop")]
    public class Stop : EntityBase
    {

        [StringLength(50, ErrorMessage = "Allowable field size (50)")]
        public string Name { get; set; }

        [Column(TypeName = "float(10)")]
        public double Latitude { get; set; }

        [Column(TypeName = "float(10)")]
        public double Longitude { get; set; }

        //public IList<Line> Lines { get; set; }
    }
}