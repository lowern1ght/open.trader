using Minio;
using System.Net;
using Trader.Exchange.Service.Clients;
using Trader.Exchange.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Trader.Configuration.Models;

namespace Trader.Exchange.Service.Dependency;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add to service collection exchange services
    /// </summary>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static IServiceCollection AddExchangeServices(this IServiceCollection collection)
    {
        collection.AddHttpContextAccessor();
        
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                               SecurityProtocolType.Tls11 |
                                               SecurityProtocolType.Tls12 |
                                               SecurityProtocolType.Tls13;
        
        collection.AddScoped<IMinioClient, MinioClient>(provider =>
        {
            var s3Settings = provider.GetRequiredService<S3Settings>();

            return (MinioClient)new MinioClient()
                .WithEndpoint(s3Settings.Host)
                .WithCredentials(s3Settings.Key, s3Settings.Secret)
                .WithSSL(false)
                .Build();
        });
        
        collection.AddScoped<IExchangeClient, ExchangeClient>();
        collection.AddScoped<IExchangeService, ExchangeService>();
        collection.AddScoped<IExchangeImageService, ExchangeImageService>();
        
        return collection;
    }
}