using System.ComponentModel.DataAnnotations;

namespace Trader.Identity.Service.Models;

public class LoginModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}