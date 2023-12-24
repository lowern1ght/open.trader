using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using Trader.Models.Configuration;
using Trader.Services.Exchange;

namespace Trader.Extensions.Others;

public static class TraderServiceCollectionExtensions
{
    /// <summary>
    ///     Add exchange service
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddExchangeService(this IServiceCollection serviceCollection)
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                               SecurityProtocolType.Tls11 |
                                               SecurityProtocolType.Tls12 |
                                               SecurityProtocolType.Tls13;

        serviceCollection.AddScoped<IMinioClient, MinioClient>(provider =>
        {
            var s3Settings = provider.GetRequiredService<S3Settings>();

            return (MinioClient)new MinioClient()
                .WithEndpoint(s3Settings.Host)
                .WithCredentials(s3Settings.Key, s3Settings.Secret)
                .WithSSL(false)
                .Build();
        });

        serviceCollection.AddScoped<IExchangeService, ExchangeService>();

        return serviceCollection;
    }
}