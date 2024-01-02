namespace Trader.Exchange.Service.Models;

public class Exchange
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string BaseUrl { get; set; }
    public required string DisplayName { get; set; }
    public required string ResourceName { get; set; }
}