using Trader.Enums.Exchange;

namespace Trader.Futures.Core.Settings.Deribit;

public class GridTradingOptions
{
    public OrderType Type { get; set; }
    
    public int OrdersCount { get; set; }
    
    public int OrderSizeUsd { get; set; }
    
    public int MarginBetweenOrders { get; set; }
    
    public int DeviationFromСurrentPrice { get; set; }
    
    public string InstrumentName { get; set; } = string.Empty;
}