using System.ComponentModel.DataAnnotations;

namespace Services.Commons.Dtos
{
    public class ParadaNaLinhaDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public long LinhaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public long ParadaId { get; set; }
    }
}