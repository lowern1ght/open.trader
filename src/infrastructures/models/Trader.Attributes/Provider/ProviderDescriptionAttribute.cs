namespace Trader.Attributes.Provider;

[AttributeUsage(AttributeTargets.Class)]
public class ProviderDescriptionAttribute : Attribute
{
    /// <summary>
    /// Name in view
    /// </summary>
    public required string Title { get; init; }
    
    /// <summary>
    /// Base url provider
    /// </summary>
    public required string BaseUrl { get; init; }
    
    /// <summary>
    /// Unique name identification provider
    /// </summary>
    public required string UniqueName { get; init; }
    
    /// <summary>
    /// Resource name in S3 storage
    /// </summary>
    public required string ImageIdentification { get; init; }
}