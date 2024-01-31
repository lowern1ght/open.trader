namespace Trader.Exchange.Service.Interfaces;

public interface IExchangeClient
{
    Task<IEnumerable<Models.Exchange>> GetCollectionAsync(CancellationToken token);
}