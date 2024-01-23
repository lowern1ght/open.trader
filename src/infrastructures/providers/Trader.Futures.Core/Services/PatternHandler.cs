using Trader.Pattern.Interfaces;
using Microsoft.Extensions.Logging;
using Trader.Pattern.Models.Common;
using Microsoft.Extensions.Caching.Memory;

namespace Trader.Futures.Core.Services;

public class PatternHandler : IPatternHandler
{
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger<PatternHandler> _logger;

    public PatternHandler(ILogger<PatternHandler> logger, IMemoryCache memoryCache)
    {
        _logger = logger;
        _memoryCache = memoryCache;
    }
    
    public Task StopPatternAsync(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> StartPatternAsync(IPattern<IPatternSettings> pattern, IPatternSettings patternSettings, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PatternState<IPattern<IPatternSettings>, IPatternSettings>>> CollectionPatternAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }
}