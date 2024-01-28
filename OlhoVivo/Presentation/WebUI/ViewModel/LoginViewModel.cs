using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModel;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o Email!")]
    [EmailAddress(ErrorMessage = "Email Inválido!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe a Senha")]
    [StringLength(20, ErrorMessage = "O {0} deve ter pelo menos {2} e {1} caracteres longos", MinimumLength = 10)]
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string ReturnUrl { get; set; }
}
