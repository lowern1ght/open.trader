using System.ComponentModel.DataAnnotations;

namespace Trader.Identity.Service.Models;

public class UserModel
{
    [Required]
    public required string Id { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public required string Username { get; set; }
}