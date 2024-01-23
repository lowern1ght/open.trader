using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trader.Storage.Inventory.Models;

public class DeribitSecret
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    [StringLength(250, MinimumLength = 0)]
    public required string Key { get; set; }

    [Required]
    [StringLength(250, MinimumLength = 0)]
    public required string Secret { get; set; }
}