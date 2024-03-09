using System.ComponentModel.DataAnnotations;

namespace OpenTrader.Identity.Service.Models;

public class RegisterModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public required string Username { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Password not equals")]
    public required string PasswordConfirm { get; set; }
}