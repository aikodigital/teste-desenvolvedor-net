using System.ComponentModel.DataAnnotations;

namespace Services.Commons.Dtos
{
    public class VeiculoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Modelo { get; set; }

        public LocalizacaoDto Localizacao { get; set; }
    }
}