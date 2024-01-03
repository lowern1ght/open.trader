namespace Trader.Pattern.Interfaces;

public interface IExchangeHandler
{
    Task HandleAsync<TPatternSettings>(string patternName, TPatternSettings settings, CancellationToken token)
        where TPatternSettings : IPatternSettings;
}