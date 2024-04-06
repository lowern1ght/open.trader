using MassTransit;

namespace OpenTrader.Pattern.Core.Dependency;

public static class BusRegistrationConfiguratorExtensions
{
    /// <summary>
    /// Configure default options to OpenTrader.Patterns services
    /// </summary>
    /// <param name="configurator"></param>
    /// <returns></returns>
    public static IBusRegistrationConfigurator DefaultSettings(this IBusRegistrationConfigurator configurator)
    {
        configurator.SetKebabCaseEndpointNameFormatter();
        return configurator;
    }
}