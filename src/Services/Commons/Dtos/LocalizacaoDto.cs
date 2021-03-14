using System.ComponentModel.DataAnnotations;

namespace Services.Commons.Dtos
{
    public class LocalizacaoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public float Latitude { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public float Longitude { get; set; }
    }
}