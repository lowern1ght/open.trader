namespace OpenTrader.Exchange.Service.Interfaces;

public interface IExchangeService
{
    Task<IEnumerable<Models.Exchange>> ListAsync(CancellationToken token);
}