using Trader.Futures.Core.Models;

namespace Trader.Futures.Core.Interfaces;

public interface IGridPatternService
{
    Task HandleLongOrders(TradingDescription tradingDescription, CancellationToken token);
    Task HandleShortOrders(TradingDescription tradingDescription, CancellationToken token);
}