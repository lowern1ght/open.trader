using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using Trader.Constants.General;
using Trader.Exchange.Service.Interfaces;

namespace Trader.Exchange.Service;

public class ExchangeImageService : IExchangeImageService
{
    private readonly IMinioClient _minioClient;
    private readonly IExchangeService _exchangeService;
    private readonly HttpContextAccessor _contextAccessor;

    public ExchangeImageService(IMinioClient minioClient, HttpContextAccessor contextAccessor, 
        IExchangeService exchangeService)
    {
        _minioClient = minioClient;
        _contextAccessor = contextAccessor;
        _exchangeService = exchangeService;
    }
    
    public async Task DownloadImageById(Guid id, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        if (_contextAccessor.HttpContext is null)
        {
            throw new InvalidOperationException($"{nameof(_contextAccessor.HttpContext)} is null");
        }

        var (response, exchange) = (_contextAccessor.HttpContext.Response, 
            await _exchangeService.GetByIdAsync(id, token));

        var statArgs = new StatObjectArgs()
            .WithObject(exchange.ResourceName)
            .WithBucket(S3Storage.ExchangeBucketName);

        var objectStat = await _minioClient.StatObjectAsync(statArgs, token);

        response.ContentType = objectStat.ContentType;

        var objectArgs = new GetObjectArgs()
            .WithObject(exchange.ResourceName)
            .WithBucket(S3Storage.ExchangeBucketName)
            .WithCallbackStream(async (stream, cancellationToken) =>
            {
                await stream.CopyToAsync(response.Body, cancellationToken);
            });

        await _minioClient.GetObjectAsync(objectArgs, token);
    }
}