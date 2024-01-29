using Flurl;
using Flurl.Http;
using Trader.Configuration.Models;
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

        throw new NotImplementedException();
        
        return await _traderServices.Urls[nameof(Sections.Futures)]
            .AppendPathSegment(Constants.Clients.ExchangeClient.CollectionAll)
            .GetJsonAsync<IEnumerable<Models.Exchange>>(cancellationToken: token);
    }
}