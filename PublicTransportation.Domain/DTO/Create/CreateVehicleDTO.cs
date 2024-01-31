using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.Domain.DTO.Create
{
    public class CreateVehicleDTO
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [MinLength(3)]
        public string Model { get; set; }

        [Required]
        public long LineId { get; set; }
    }
}
