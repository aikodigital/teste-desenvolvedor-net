using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.App.Models.Vehicles
{
    public class VehiclePosition
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}
