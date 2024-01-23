using Trader.Pattern.Attributes;
using Trader.Pattern.Interfaces;

namespace Trader.Pattern.Models.Common;

public class PatternState<TPattern, TPatternSettings>
    where TPatternSettings : IPatternSettings
    where TPattern : IPattern<TPatternSettings>
{
    public Guid Id { get; set; }
    public required TPattern Pattern { get; init; }
    public required TPatternSettings PatternSettings { get; init; }

    public required PatternMetaAttribute PatternMeta { get; set; }
    
    public required CancellationTokenSource TokenSource { get; init; } = new();

    public PatternState(TPattern pattern, TPatternSettings patternSettings)
    {
        Pattern = pattern; 
        PatternSettings = patternSettings;
    }
}