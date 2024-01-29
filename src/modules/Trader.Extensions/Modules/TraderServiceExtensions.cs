using Trader.Configuration.Models;

namespace Trader.Extensions.Modules;

public static class TraderServiceExtensions
{
    /// <summary>
    ///     Find value equals Futures
    /// </summary>
    /// <param name="traderServices"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static TraderServiceDescription GetFuturesDescription(this TraderServices traderServices)
    {
        var keyValuePair = traderServices.Urls.FirstOrDefault(description =>
            description.Key == nameof(Sections.Futures));

        return new TraderServiceDescription
        {
            Name = keyValuePair.Key,
            Url = keyValuePair.Value
        };
    }

    /// <summary>
    ///     Find value equals Options
    /// </summary>
    /// <param name="traderServices"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static TraderServiceDescription GetOptionsDescription(this TraderServices traderServices)
    {
        var keyValuePair = traderServices.Urls.FirstOrDefault(description =>
            description.Key == nameof(Sections.Options));

        return new TraderServiceDescription
        {
            Name = keyValuePair.Key,
            Url = keyValuePair.Value
        };
    }
}