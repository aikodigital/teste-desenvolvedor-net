using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.Domain.DTO.Create
{
    public class CreateLineDTO
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public ICollection<CreateLineStopDTO>? Stops { get; set; }
    }
}
