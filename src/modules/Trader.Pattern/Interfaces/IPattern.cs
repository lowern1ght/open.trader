namespace Trader.Pattern.Interfaces;

public interface IPattern<in TPatternSettings>
    where TPatternSettings : IPatternSettings
{
    Task InvokeAsync(TPatternSettings settings, CancellationToken token);
}