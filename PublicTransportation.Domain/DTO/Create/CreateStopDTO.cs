using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.Domain.DTO.Create
{
    public class CreateStopDTO
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

    }
}
