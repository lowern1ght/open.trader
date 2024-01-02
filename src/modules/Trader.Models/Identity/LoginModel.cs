using System.ComponentModel.DataAnnotations;

namespace Trader.Models.Identity;

public class LoginModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required] public required bool RememberMe { get; set; } = false;
}