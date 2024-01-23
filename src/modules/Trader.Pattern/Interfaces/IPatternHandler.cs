using Trader.Pattern.Models.Common;

namespace Trader.Pattern.Interfaces;

public interface IPatternHandler
{
    Task StopPatternAsync(Guid id, CancellationToken token);
    Task<Guid> StartPatternAsync(IPattern<IPatternSettings> pattern, IPatternSettings patternSettings, CancellationToken token);
    Task<IEnumerable<PatternState<IPattern<IPatternSettings>, IPatternSettings>>> CollectionPatternAsync(CancellationToken token);
}