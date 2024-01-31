using PublicTransportation.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.Domain.DTO.Create
{
    public class CreateLineStopDTO
    {
        [Required]
        public long LineId { get; set; }

        [Required]
        public long StopId { get; set; }
    }
}
