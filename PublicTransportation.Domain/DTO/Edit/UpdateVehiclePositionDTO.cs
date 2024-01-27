using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.Domain.DTO.Edit
{
    public class UpdateVehiclePositionDTO
    {
        [Required]
        public double Logitude { get; set; }

        [Required]
        public double Latitude { get; set; }
    }
}
