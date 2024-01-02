using Trader.Constants.General;
using Trader.Storage.Inventory.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trader.Storage.Inventory.Models;

public class Exchange
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; } = Guid.NewGuid();

    [Required]
    [StringLength(50, MinimumLength = 0)]
    public required string Name { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 0)]
    public required string BaseUrl { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 0)]
    public required string DisplayName { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 0)]
    [Bucket(BucketName = S3Storage.ExchangeBucketName)]
    public required string ResourceName { get; set; }
}