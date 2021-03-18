using System.ComponentModel.DataAnnotations;

namespace Services.Commons.Dtos
{
    public class LocalizacaoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public double Longitude { get; set; }
    }
}