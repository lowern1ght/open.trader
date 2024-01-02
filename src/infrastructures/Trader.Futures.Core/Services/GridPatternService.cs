using Microsoft.Extensions.Logging;
using Trader.Futures.Core.Clients;
using Trader.Futures.Core.Interfaces;
using Trader.Futures.Core.Models;

namespace Trader.Futures.Core.Services;

public class GridPatternService : IGridPatternService
{
    private readonly ILogger<GridPatternService> _logger;
    private readonly DeribitHttpClient _deribitHttpClient;
    
    public GridPatternService(DeribitHttpClient deribitHttpClient, ILogger<GridPatternService> logger)
    {
        _logger = logger;
        _deribitHttpClient = deribitHttpClient;
    }
    
    public async Task HandleLongOrders(TradingDescription tradingDescription, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task HandleShortOrders(TradingDescription tradingDescription, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}