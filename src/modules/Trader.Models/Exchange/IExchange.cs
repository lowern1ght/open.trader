namespace Trader.Models.Exchange;

public interface IExchange
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string BaseUrl { get; set; }
}