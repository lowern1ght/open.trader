namespace Trader.Models.Exchange;

public class ExchangeDescription
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string BaseUrl { get; set; }
    public required string DisplayName { get; set; }
    public required string ResourceName { get; set; }
}