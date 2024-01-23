using Trader.Constants;
using Trader.Enums.Exchange;
using Trader.Helpers.Orders;
using Trader.Client.Deribit;
using Trader.Pattern.Attributes;
using Trader.Pattern.Interfaces;
using Trader.Models.Configuration;
using Microsoft.Extensions.Logging;
using Trader.Client.Deribit.Models;
using Trader.Futures.Core.Settings.Deribit;

namespace Trader.Futures.Core.Patterns.Deribit;

[PatternMeta(Name = "Grid pattern", ServicesEnumeration = ServicesEnumeration.Futures, ProviderType = typeof(Providers.Deribit))]
public class DeribitGridPattern : IPattern<GridPatternSettings>
{
    private readonly DeribitClient _deribitClient;
    private readonly ILogger<DeribitGridPattern> _logger;

    /// <summary>
    /// Updatable limit price(Mark price, Mid price) 
    /// </summary>
    private decimal MidPrice { get; set; } = decimal.One;
    
    public DeribitGridPattern(ILogger<DeribitGridPattern> logger, DeribitClient deribitClient)
    {
        _logger = logger;
        _deribitClient = deribitClient;
        deribitClient.BaseUrl = Providers.Deribit.Url;
    }
    
    public async Task InvokeAsync(GridPatternSettings settings, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            var orders = (await _deribitClient.PrivateOpenOrdersByInstrumentAsync(
                settings.TradingOptions.InstrumentName,
                settings.TradingOptions.Type, token)).ToArray();
            
            if (settings.LongOrders)
            {
                await InvokeOrdersDirectionAsync(settings.TradingOptions, OrderMethod.Buy, settings.UserId, orders, token);
            }

            if (settings.ShortOrders)
            {
                await InvokeOrdersDirectionAsync(settings.TradingOptions, OrderMethod.Sell, settings.UserId, orders, token);
            }

            await Task.Delay(settings.Duration, token);
        }
    }

    #region System handled

    private async Task InvokeOrdersDirectionAsync(GridTradingOptions tradingOptions, OrderMethod method, Guid userId,
        IReadOnlyCollection<OrderModel> orders, CancellationToken token)
    {
        if (orders.Count >= tradingOptions.OrdersCount)
            return;

        var sendOrdersCollection = new List<OrderModel>();
        
        var lastPrice = orders.Count == 0
            ? decimal.Zero
            : orders.Last().Price;
        
        for (var i = 0; i < tradingOptions.OrdersCount - orders.Count; i++)
        {
            var order = new OrderModel
            {
                Type = method,
                Label = LabelHelper.GenerateOrderLabel(),
                Amount = tradingOptions.OrderSizeUsd,
                Price = lastPrice == decimal.Zero 
                    ? MidPrice + tradingOptions.DeviationFromСurrentPrice
                    : lastPrice + tradingOptions.MarginBetweenOrders
            };
            
            sendOrdersCollection.Add(order);
            
            lastPrice = order.Price;
        }

        var createdOrders = await _deribitClient.PrivateTradingOrdersAsync(
            tradingOptions.InstrumentName,
            sendOrdersCollection,
            token);
        
        throw new NotImplementedException();
    }

    #endregion
}