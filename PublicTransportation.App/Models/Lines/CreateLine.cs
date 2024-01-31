using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.App.Models.Lines
{
    public class CreateLine
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public ICollection<LineStop>? Stops { get; set; }
    }
}
