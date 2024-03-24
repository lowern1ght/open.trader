using OpenTrader.Logger.Models;
using Microsoft.Extensions.Configuration;

namespace OpenTrader.Logger.Dependency;

public static class ConfigurationExtensions
{
    public static LoggerOptions? LoggerOptions(this IConfiguration configuration)
    {
        return configuration.GetSection(nameof(Models.LoggerOptions))
            .Get<LoggerOptions>();
    }
}