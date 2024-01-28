using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs;

public class RegisterDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "As senhas não correspondem!")]
    public string ConfirmPassword { get; set; }
}
