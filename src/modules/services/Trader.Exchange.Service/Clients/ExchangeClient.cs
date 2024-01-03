using Flurl;
using Flurl.Http;
using Trader.Models.Configuration;
using Trader.Exchange.Service.Interfaces;

namespace Trader.Exchange.Service.Clients;

public class ExchangeClient : IExchangeClient
{
    private readonly TraderServices _traderServices;

    public ExchangeClient(TraderServices traderServices)
    {
        _traderServices = traderServices;
    }
    
    /// <summary>
    /// Send GET Request to Exchange Api and return exchanges list
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Models.Exchange>> GetCollectionAsync(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        
        return await _traderServices.Urls[nameof(ServicesEnumeration.Exchanges)]
            .AppendPathSegment(Constants.Clients.ExchangeClient.CollectionAll)
            .GetJsonAsync<IEnumerable<Models.Exchange>>(cancellationToken: token);
    }
}