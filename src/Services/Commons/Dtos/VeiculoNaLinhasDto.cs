using System.ComponentModel.DataAnnotations;

namespace Services.Commons.Dtos
{
    public class VeiculoNaLinhasDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public long LinhaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public long VeiculoId { get; set; }
    }
}