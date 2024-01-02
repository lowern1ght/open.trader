namespace Trader.Models.Exchange.Interfaces;

public interface IExchange
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BaseUrl { get; set; }
    public string DisplayName { get; set; }
    public string ResourceName { get; set; }
}