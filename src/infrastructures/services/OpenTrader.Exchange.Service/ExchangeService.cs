using OpenTrader.Exchange.Service.Interfaces;

namespace OpenTrader.Exchange.Service;

public class ExchangeService(IExchangeClient exchangeClient) : IExchangeService
{
    /// <summary>
    /// Get all exchanges
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Models.Exchange>> ListAsync(CancellationToken token)
    {
        return await exchangeClient.ListAsync(token);
    }
}