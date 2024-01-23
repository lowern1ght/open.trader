using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trader.IdentityProviders.Service.Models;

public class ProviderAuthorizationModel
{
    [Key]
    [Required]
    public required Guid Id { get; set; }
    
    [Required]
    [Description("Secret key for auth")]
    [StringLength(250, MinimumLength = 0)]
    public required string Key { get; set; }

    [Required]
    [Description("Secret token for auth")]
    [StringLength(250, MinimumLength = 0)]
    public required string Secret { get; set; }
}