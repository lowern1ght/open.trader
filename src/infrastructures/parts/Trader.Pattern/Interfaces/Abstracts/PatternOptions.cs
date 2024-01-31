using Trader.Enums.Settings;

namespace Trader.Pattern.Interfaces.Abstracts;

public class PatternOptions : IPatternOptions
{
    /// <summary>
    /// Work pause between iteration of bot
    /// </summary>
    public TimeSpan Duration { get; } = Constants.Pattern.Settings.DefaultDuration;
    
    /// <summary>
    /// If pattern stopped if error or stopped server => settings
    /// </summary>
    public PatternReload Restart { get; init; } = PatternReload.None;
}