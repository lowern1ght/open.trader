namespace Trader.Futures.Core.Models;

public class TradingDescription
{
    /// <summary>
    /// Trading tool used by bot
    /// </summary>
    public required string InstrumentName { get; set; }
    
    /// <summary>
    /// Order price in USD currency
    /// </summary>
    public int OrderSizeUsd { get; set; }
    
    /// <summary>
    /// Space between orders in USD
    /// </summary>
    public int MarginBetweenOrders { get; set; }
    
    /// <summary>
    /// Offset of the beginning of the grid from the current price of the instrument
    /// </summary>
    public int DeviationFromСurrentPrice { get; set; }
    
    /// <summary>
    /// Number of orders in one of the grids
    /// </summary>
    public int OrdersCount { get; set; }
}