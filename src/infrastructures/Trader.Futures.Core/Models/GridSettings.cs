using Trader.Pattern.Interfaces;

namespace Trader.Futures.Core.Models;

public class GridSettings : IPatternSettings
{
    /// <summary>
    /// Pause between processing the current template
    /// </summary>
    public TimeSpan BreakBetweenTreatments { get; init; } = TimeSpan.FromSeconds(1);
    
    /// <summary>
    /// Do we trade purchase orders
    /// </summary>
    public bool ShortOrders { get; set; } = false;
    
    /// <summary>
    /// Do we trade sell orders
    /// </summary>
    public bool LongOrders { get; set; } = false;
    
    /// <summary>
    /// Trading settings for the bot
    /// </summary>
    public required TradingDescription TradingDescription { get; init; }
}