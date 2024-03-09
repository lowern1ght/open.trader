using Microsoft.Extensions.Configuration;
using OpenTrader.Identity.Service.Models.Configuration;

namespace OpenTrader.Identity.Service.Dependency;

public static class ConfigurationExtensions
{
    /// <summary>
    /// Get IdentityConfig from configuration
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static IdentityConfig GetIdentityConfig(this IConfiguration configuration)
    {
        var identityConfig = configuration.GetSection(nameof(IdentityConfig))
            .Get<IdentityConfig>();

        if (identityConfig is null)
        {
            throw new InvalidOperationException($"{nameof(identityConfig)} is null, invalid operation");
        }
        
        return identityConfig;
    }
}