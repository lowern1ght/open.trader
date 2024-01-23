using Polly;
using System.Net;
using Trader.Constants;
using Trader.Enums.Exchange;
using Trader.Client.Interfaces;
using Trader.Models.Clients.Secret;
using Microsoft.Extensions.Logging;
using Trader.Client.Deribit.Models;

namespace Trader.Client.Deribit;

public class DeribitClient : IExchangeClient<Providers.Deribit>, IReinitializeClient<ClientAuthorizationModel>
{
    protected HttpClient Client { get; set; } = new();
    public string BaseUrl { get; set; } = Providers.Deribit.Url;
    
    public DeribitClient() { }
    
    public Task<HttpClient> ReinitializeClientAsync(ClientAuthorizationModel model, CancellationToken token)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Retrieves history of orders that have been partially or fully filled.
    /// </summary>
    /// <param name="instrumentName"></param>
    /// <param name="type"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<IEnumerable<OrderModel>> PrivateOpenOrdersByInstrumentAsync(string instrumentName, OrderType type, CancellationToken token)
    {
        if (instrumentName.Length == 0)
        {
            throw new ArgumentNullException(nameof(instrumentName));
        }

        /*var responseModel = await Providers.Deribit.Url
            .AppendPathSegment(Constants.Urls.DeribitCommon.Order.ListByInstrument)
            .SetQueryParams(new { instrumentName, type = type.ToSnakeCase() })
            .GetJsonAsync<ListOrderResponse>(cancellationToken: token);*/

        // return responseModel?.Result is not null
        //     ? responseModel.Result.Adapt<IEnumerable<OrderModel>>()
        //     : Array.Empty<OrderModel>();

        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderModel>> PrivateTradingOrdersAsync(string instrumentName, List<OrderModel> orders, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}