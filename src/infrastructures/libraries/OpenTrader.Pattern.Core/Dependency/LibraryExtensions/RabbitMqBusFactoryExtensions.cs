using MassTransit;
using OpenTrader.Pattern.Core.Models.Configuration;

namespace OpenTrader.Pattern.Core.Dependency.LibraryExtensions;

public static class RabbitMqBusFactoryExtensions
{
    /// <summary> Configure RabbitMq host configuration from <see cref="BrokerSettings"/> </summary>
    /// <param name="configurator"></param>
    /// <param name="brokerSettings"></param>
    /// <returns></returns>
    public static IRabbitMqBusFactoryConfigurator HostFromSettings(
        this IRabbitMqBusFactoryConfigurator configurator,
        BrokerSettings brokerSettings)
    {
        configurator.Host(brokerSettings.ConnectionSettings.Host,
            brokerSettings.ConnectionSettings.Port,
            brokerSettings.ConnectionSettings.VirtualPath,
            hostConfigurator =>
            {
                hostConfigurator.Username(brokerSettings.Username);
                hostConfigurator.Password(brokerSettings.Password);
            });
        
        return configurator;
    }
}