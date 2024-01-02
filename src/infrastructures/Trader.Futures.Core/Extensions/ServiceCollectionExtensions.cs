using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Trader.Futures.Core.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add to DI all futures required services
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddFuturesServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection;
    }
}