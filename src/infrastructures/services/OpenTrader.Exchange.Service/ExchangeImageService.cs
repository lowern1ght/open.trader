using Minio;
using Minio.DataModel.Args;
using OpenTrader.Constants.General;
using Microsoft.AspNetCore.Http;
using OpenTrader.Exchange.Service.Interfaces;
using OpenTrader.Exchange.Service.Models;

namespace OpenTrader.Exchange.Service;

public class ExchangeImageService(IMinioClient minioClient, IHttpContextAccessor contextAccessor) : IExchangeImageService
{
    /// <summary>
    /// Copy image bytes with content type to "HttpResponse" Body
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="token"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ImageResult> DownloadImageByName(string fileName, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        if (contextAccessor.HttpContext is null)
        {
            throw new InvalidOperationException($"{nameof(contextAccessor.HttpContext)} is null");
        }
        
        var statArgs = new StatObjectArgs()
            .WithObject(fileName)
            .WithBucket(S3Storage.ExchangeBucketName);

        var objectStat = await minioClient.StatObjectAsync(statArgs, token);

        var imageResult = new ImageResult
        {
            Name = objectStat.ObjectName,
            ContentType = objectStat.ContentType,
            FileStream = new MemoryStream()
        };
        
        var objectArgs = new GetObjectArgs()
            .WithObject(fileName)
            .WithBucket(S3Storage.ExchangeBucketName)
            .WithCallbackStream(async (stream, cancellationToken) =>
            {
                await stream.CopyToAsync(imageResult.FileStream, cancellationToken);
            });

        await minioClient.GetObjectAsync(objectArgs, token);

        return imageResult;
    }
}