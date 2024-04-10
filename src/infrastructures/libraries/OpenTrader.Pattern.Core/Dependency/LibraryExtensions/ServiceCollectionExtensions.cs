using MassTransit;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTrader.Pattern.Core.Exceptions.Configuration;
using OpenTrader.Pattern.Core.Extensions;
using OpenTrader.Pattern.Core.Models.Configuration;

namespace OpenTrader.Pattern.Core.Dependency.LibraryExtensions;

public static class ServiceCollectionExtensions
{
    /// <summary> Add <see cref="MassTransit"/> with settings to this project </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="configuration"></param>
    /// <param name="entryConfigure"></param>
    /// <exception cref="NotFoundBrokerSettings">
    ///     if <see cref="BrokerSettings"/>
    ///     not exists contextual
    ///     <see cref="OpenTrader.Pattern.Core.Models.Configuration"/> </exception>
    public static IServiceCollection AddTraderMassTransit(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator>? entryConfigure = null)
    {
        if (configuration.RabbitMqSettings() is not {} rabbitMqSettings)
            throw new NotFoundBrokerSettings();

        var entryAssembly = Assembly.GetEntryAssembly();
        
        serviceCollection.AddMassTransit(configurator =>
        {
            configurator.DefaultSettings();

            if (entryAssembly.IsExistsConsumers())
            {
                configurator.AddConsumers(entryAssembly);
            }
            
            configurator.UsingRabbitMq((context, factoryConfigurator) =>
            {
                factoryConfigurator.HostFromSettings(rabbitMqSettings);
                
                //Invoke entry action to configure all options
                entryConfigure?.Invoke(context, factoryConfigurator);

                factoryConfigurator.ConfigureEndpoints(context);
            });
        });

        return serviceCollection;
    }
}