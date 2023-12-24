using System.ComponentModel.DataAnnotations;
using Trader.Models.Base;

namespace Trader.Models.Identity;

public class RegisterEmailModel : BaseModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [Required] [DataType(DataType.Text)] public required string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
}