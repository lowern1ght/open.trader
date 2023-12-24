using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Trader.Storage.Inventory.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Add inventory db context to service collection
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddInventoryDbContext(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<InventoryDbContext>(builder =>
        {
            builder.UseSnakeCaseNamingConvention(CultureInfo.InvariantCulture)
                .UseNpgsql(configuration.GetConnectionString(nameof(InventoryDbContext)));
        });

        return serviceCollection;
    }
}