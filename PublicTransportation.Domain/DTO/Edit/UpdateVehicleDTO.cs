using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.Domain.DTO.Edit
{
    public class UpdateVehicleDTO
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [MinLength(3)]
        public string Model { get; set; }

        [Required]
        public long LineId { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }
    }
}
