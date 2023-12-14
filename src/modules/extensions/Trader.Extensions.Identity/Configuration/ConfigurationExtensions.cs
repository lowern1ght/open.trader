using Microsoft.Extensions.Configuration;
using Trader.Extensions.Identity.Models;

namespace Trader.Extensions.Identity.Configuration;

public static class ConfigurationExtensions
{
    /// <summary>
    ///     Get IdentityConfig from configuration
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static IdentityConfig IdentityConfig(this IConfiguration configuration)
    {
        var identityConfig = configuration.GetSection(nameof(IdentityConfig))
            .Get<IdentityConfig>();

        return identityConfig ?? throw new InvalidOperationException();
    }
}