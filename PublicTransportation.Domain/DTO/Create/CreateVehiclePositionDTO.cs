using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.Domain.DTO.Create
{
    public class CreateVehiclePositionDTO
    {
        [Required]
        public double Logitude { get; set; }

        [Required]
        public double Latitude { get; set; }
    }
}
