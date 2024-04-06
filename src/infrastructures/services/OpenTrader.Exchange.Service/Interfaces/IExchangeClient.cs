namespace OpenTrader.Exchange.Service.Interfaces;

public interface IExchangeClient
{
    Task<IEnumerable<Models.Exchange>> ListAsync(CancellationToken token);
}