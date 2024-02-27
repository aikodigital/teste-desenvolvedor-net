using System.ComponentModel.DataAnnotations;

namespace AikoDigital.Models
{
    public class PosicaoVeiculo
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
        
        
        public long VeiculoId { get; set; }
    }
}
