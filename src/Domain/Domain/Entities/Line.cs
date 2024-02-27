using SharedKernel.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Line")]
    public class Line : EntityBase
    {
        
        [ForeignKey("Stop")]
        public long StopId { get; set; }
                
        [StringLength(50, ErrorMessage = "Allowable field size (50)")]
        public string Name { get; set; }

        public Stop Stop { get; set; }
    }
}
