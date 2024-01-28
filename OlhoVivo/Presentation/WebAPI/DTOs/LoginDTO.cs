using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs;

public class LoginDTO
{
    [EmailAddress(ErrorMessage = "Email Inválido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe a Senha")]
    [StringLength(20, ErrorMessage = "O {0} deve ter pelo menos {2} e {1} caracteres longos", MinimumLength = 10)]
    public string Password { get; set; }
}
