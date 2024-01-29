using PublicTransportation.App.Models.Stops;
using PublicTransportation.App.Models.Vehicles;
using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.App.Models.Lines
{
    public class Line
    {
        public long Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public ICollection<Stop> Stops { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
