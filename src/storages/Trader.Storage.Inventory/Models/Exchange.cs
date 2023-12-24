using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trader.Constants;
using Trader.Storage.Inventory.Attributes;

namespace Trader.Storage.Inventory.Models;

public class Exchange
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 0)]
    public required string Title { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 0)]
    [Bucket(BucketName = S3Storage.ExchangeBucketName)]
    public required string ResourceName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 0)]
    public required string BaseUrl { get; set; }
}