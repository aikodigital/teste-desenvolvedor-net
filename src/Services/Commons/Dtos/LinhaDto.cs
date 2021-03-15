using System.ComponentModel.DataAnnotations;

namespace Services.Commons.Dtos
{
    public class LinhaDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }
    }
}