using Microsoft.Extensions.Configuration;
using OpenTrader.Pattern.Core.Models.Configuration;

namespace OpenTrader.Pattern.Core.Dependency;

public static class ConfigurationExtensions
{
    /// <summary>
    /// Return all settings from section BrokerSettings
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IEnumerable<BrokerSettings> BrokerSettings(this IConfiguration configuration)
    {
        return configuration.GetSection(nameof(Models.Configuration.BrokerSettings))
            .Get<BrokerSettings[]>() ?? Array.Empty<BrokerSettings>();
    }
    
    /// <summary>
    /// Return <see cref="BrokerSettings"/> by broker name
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="name"></param>
    private static BrokerSettings? BrokerSettings(this IConfiguration configuration, string name)
    {
        var settingsArray = configuration
            .GetSection(nameof(Models.Configuration.BrokerSettings))
            .Get<BrokerSettings[]>();

        return settingsArray?.First(settings => string.Equals(
                settings.Title, 
                name, 
                StringComparison.CurrentCultureIgnoreCase));
    }

    #region Brokers

    /// <summary>
    /// Return <see cref="OpenTrader.Pattern.Core.Models.Configuration.BrokerSettings"/> for <see cref="RabbitMQ.Client"/>
    /// </summary>
    /// <param name="configuration"></param>
    public static BrokerSettings? RabbitMqSettings(this IConfiguration configuration) 
        => configuration.BrokerSettings(PatternDefault.Brokers.RabbitMq);
    
    /// <summary>
    /// Return <see cref="OpenTrader.Pattern.Core.Models.Configuration.BrokerSettings"/> for <see cref="Confluent.Kafka"/>
    /// </summary>
    /// <param name="configuration"></param>
    public static BrokerSettings? KafkaSettings(this IConfiguration configuration) 
        => configuration.BrokerSettings(PatternDefault.Brokers.Kafka);

    #endregion
}