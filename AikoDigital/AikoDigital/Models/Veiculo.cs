using System.ComponentModel.DataAnnotations;

namespace AikoDigital.Models
{
    public class Veiculo
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Modelo { get; set; }
        
        public long LinhaId { get; set; }

        public Linha? Linha { get; set; }
    }

}
