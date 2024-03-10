using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OpenTrader.Storage.Account.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Add to service collection IdentityTraderDbContext
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddIdentityTraderDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<IdentityTraderDbContext>(builder =>
        {
            builder.UseSnakeCaseNamingConvention(CultureInfo.InvariantCulture)
                .UseNpgsql(configuration.GetConnectionString(nameof(IdentityTraderDbContext)));
        });

        return serviceCollection;
    }
}