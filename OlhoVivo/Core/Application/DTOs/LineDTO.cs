using System.ComponentModel.DataAnnotations;

namespace OlhoVivo.Core.Application.DTOs;

public class LineDTO
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Informe o Nome!")]
    [MinLength(5)]
    [MaxLength(100)]
    public string Name { get; set; }
}
