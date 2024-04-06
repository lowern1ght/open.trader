using OpenTrader.Exchange.Service.Interfaces;

namespace OpenTrader.Exchange.Service.Clients;

public class ExchangeClient : IExchangeClient
{
    /// <summary>
    /// Send GET Request to Exchange Api and return exchanges list
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<IEnumerable<Models.Exchange>> ListAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }
}