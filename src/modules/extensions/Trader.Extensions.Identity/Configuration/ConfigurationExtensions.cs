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

    /// <summary>
    ///     Get IdentityServerConfig to client application
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static IdentityServerConfig IdentityServerConfig(this IConfiguration configuration)
    {
        var identityServerConfig = configuration.GetSection(nameof(Models.IdentityServerConfig))
            .Get<IdentityServerConfig>();

        return identityServerConfig ?? throw new InvalidOperationException();
    }
}