namespace Trader.Models.Exchange;

public class Exchange : IExchange
{
    public required string ResourceName { get; set; }
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string BaseUrl { get; set; }
}