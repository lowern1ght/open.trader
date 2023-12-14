using System.ComponentModel.DataAnnotations;

namespace Trader.Models.Identity;

public class RegisterEmailModel : LoginEmailModel
{
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
}