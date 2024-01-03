using Trader.Exchange.Service.Interfaces;

namespace Trader.Exchange.Service;

public class ExchangeService : IExchangeService
{
    private readonly IExchangeClient _exchangeClient;

    public ExchangeService(IExchangeClient exchangeClient)
    {
        _exchangeClient = exchangeClient;
    }
    
    /// <summary>
    /// Get all exchanges
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Models.Exchange>> CollectionAsync(CancellationToken token)
    {
        return await _exchangeClient.GetCollectionAsync(token);
    }
}