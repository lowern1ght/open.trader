namespace OpenTrader.Exchange.Service.Models;

public class ImageResult
{
    public required string Name { get; init; }
    
    public required Stream FileStream { get; init; }
    
    public required string ContentType { get; init; }
}