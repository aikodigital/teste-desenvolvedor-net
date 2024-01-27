using System.ComponentModel.DataAnnotations;

namespace PublicTransportation.Domain.DTO.Edit
{
    public class UpdateLineDTO
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
