using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trader.Storage.Settings.Options;

namespace Trader.Storage.Settings.Dependency;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSettingsDbContext(this IServiceCollection collection, IConfiguration configuration)
    {
        var section = configuration
            .GetSection(Constants.Configuration.Sections.DatabasesSection)
            .GetSection(Constants.Configuration.Sections.MongoSections);
        
        return collection.Configure<SettingsDatabaseOptions>(section);
    }
}