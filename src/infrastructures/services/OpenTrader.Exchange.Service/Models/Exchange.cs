using System.ComponentModel.DataAnnotations;

namespace OpenTrader.Exchange.Service.Models;

public class Exchange
{
    /// <summary>
    /// Identification exchange
    /// </summary>
    [Key]
    [Required]
    public required string Id { get; set; }
    
    /// <summary>
    /// Name in client-render
    /// </summary>
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 2)]
    public required string Title { get; set; }
    
    /// <summary>
    /// Base url provider exchange
    /// </summary>
    [DataType(DataType.Url)]
    public required string BaseUrl { get; set; }
    
    /// <summary>
    /// Internal exchange name
    /// </summary>
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 2)]
    public required string InternalName { get; set; }
}