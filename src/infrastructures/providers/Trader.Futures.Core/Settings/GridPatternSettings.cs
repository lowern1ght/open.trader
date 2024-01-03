using Trader.Pattern.Interfaces;

namespace Trader.Futures.Core.Settings;

public class GridPatternSettings : IPatternSettings
{
    public string InstrumentTrading { get; set; } = string.Empty;
    
    public int OrderSizeUsd { get; set; }
    
    public int MarginBetweenOrders { get; set; }
    
    public int DeviationFromСurrentPrice { get; set; }
    
    public int OrdersCount { get; set; }
    
    public bool ShortOrders { get; set; } = false;
    
    public bool LongOrders { get; set; } = false;
}