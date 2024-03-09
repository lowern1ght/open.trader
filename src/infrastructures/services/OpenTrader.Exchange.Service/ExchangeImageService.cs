using Minio;
using Minio.DataModel.Args;
using OpenTrader.Constants.General;
using Microsoft.AspNetCore.Http;
using OpenTrader.Exchange.Service.Interfaces;

namespace OpenTrader.Exchange.Service;

public class ExchangeImageService : IExchangeImageService
{
    private readonly IMinioClient _minioClient;
    private readonly IHttpContextAccessor _contextAccessor;

    public ExchangeImageService(IMinioClient minioClient, IHttpContextAccessor contextAccessor)
    {
        _minioClient = minioClient;
        _contextAccessor = contextAccessor;
    }
    
    /// <summary>
    /// Copy image bytes with content type to "HttpResponse" Body
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="token"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task DownloadImageByName(string fileName, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        if (_contextAccessor.HttpContext is null)
        {
            throw new InvalidOperationException($"{nameof(_contextAccessor.HttpContext)} is null");
        }

        var response = _contextAccessor.HttpContext.Response;

        var statArgs = new StatObjectArgs()
            .WithObject(fileName)
            .WithBucket(S3Storage.ExchangeBucketName);

        var objectStat = await _minioClient.StatObjectAsync(statArgs, token);

        response.ContentType = objectStat.ContentType;

        var objectArgs = new GetObjectArgs()
            .WithObject(fileName)
            .WithBucket(S3Storage.ExchangeBucketName)
            .WithCallbackStream(async (stream, cancellationToken) =>
            {
                await stream.CopyToAsync(response.Body, cancellationToken);
            });

        await _minioClient.GetObjectAsync(objectArgs, token);
    }
}