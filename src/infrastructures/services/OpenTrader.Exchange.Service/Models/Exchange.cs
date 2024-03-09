using System.ComponentModel.DataAnnotations;

namespace OpenTrader.Exchange.Service.Models;

public class Exchange
{
    /// <summary>
    /// in app name, key, unique
    /// </summary>
    [Key]
    public required string Name { get; set; }
    
    /// <summary>
    /// Base url provider exchange
    /// </summary>
    [DataType(DataType.Url)]
    public required string BaseUrl { get; set; }
    
    /// <summary>
    /// Name in client-render
    /// </summary>
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 2)]
    public required string DisplayName { get; set; }
    
    /// <summary>
    /// File name in s3 storage
    /// </summary>
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 2)]
    public required string ResourceName { get; set; }
}