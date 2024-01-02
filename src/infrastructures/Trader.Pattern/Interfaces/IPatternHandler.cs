namespace Trader.Pattern.Interfaces;

public interface IPatternHandler<in TSettings>
    where TSettings : IPatternSettings
{
    Task Execute(TSettings settings, CancellationToken token);
}