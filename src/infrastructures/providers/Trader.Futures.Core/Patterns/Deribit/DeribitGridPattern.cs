using Trader.Constants;
using Trader.Pattern.Attributes;
using Trader.Pattern.Interfaces;
using Trader.Models.Configuration;
using Trader.Futures.Core.Settings;

namespace Trader.Futures.Core.Patterns.Deribit;

[PatternDescription("Grid pattern", ServicesEnumeration.Futures, typeof(Providers.Deribit))]
public class DeribitGridPattern : IPattern<GridPatternSettings>
{
    public Task InvokeAsync(GridPatternSettings settings, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}