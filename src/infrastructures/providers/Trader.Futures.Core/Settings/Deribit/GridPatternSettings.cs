using Trader.Futures.Core.Interfaces;
using Trader.Pattern.Interfaces;

namespace Trader.Futures.Core.Settings.Deribit;

public class GridPatternSettings : IPatternSettings, IDirectionOrdersSettings
{
    public Guid UserId { get; set; }
    
    public bool ShortOrders { get; set; } = false;
    
    public bool LongOrders { get; set; } = false;

    public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(0.5);
    
    public required GridTradingOptions TradingOptions { get; set; }
}