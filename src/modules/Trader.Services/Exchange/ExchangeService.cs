using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel.Args;
using Trader.Constants;
using Trader.Storage.Inventory;

namespace Trader.Services.Exchange;

public class ExchangeService : IExchangeService
{
    private readonly InventoryDbContext _inventoryDbContext;
    private readonly IMinioClient _minioClient;

    public ExchangeService(InventoryDbContext inventoryDbContext, IMinioClient minioClient)
    {
        _minioClient = minioClient;
        _inventoryDbContext = inventoryDbContext;
    }

    public async Task DeleteAsync(Guid id, CancellationToken token)
    {
        var exchange = await _inventoryDbContext.Exchanges.FirstOrDefaultAsync(entity => entity.Id == id, token);
        if (exchange is null) throw new InvalidOperationException($"exchange by id: {id} not found");

        _inventoryDbContext.Exchanges.Remove(exchange);
        await _inventoryDbContext.SaveChangesAsync(token);
    }

    public async Task<Models.Exchange.Exchange> GetByIdAsync(Guid id, CancellationToken token)
    {
        var exchange = await _inventoryDbContext.Exchanges.FirstOrDefaultAsync(exchange => exchange.Id == id, token);
        if (exchange is null) throw new InvalidOperationException($"exchange by id: {id} not found");

        return exchange.Adapt<Models.Exchange.Exchange>();
    }

    public async Task<Models.Exchange.Exchange> GetByNameAsync(string name, CancellationToken token)
    {
        var exchange = await _inventoryDbContext.Exchanges.FirstOrDefaultAsync(exchange 
            => exchange.Title == name, token);
        if (exchange is null) throw new InvalidOperationException($"exchange by name: {name} not found");

        return exchange.Adapt<Models.Exchange.Exchange>();
    }

    public async Task<IEnumerable<Models.Exchange.Exchange>> CollectionAsync(CancellationToken token)
    {
        var exchanges = await _inventoryDbContext.Exchanges.ToArrayAsync(token);
        return exchanges.Select(exchange => exchange.Adapt<Models.Exchange.Exchange>());
    }

    public async Task CreateAsync(Models.Exchange.Exchange exchange, CancellationToken token)
    {
        await _inventoryDbContext.Exchanges.AddAsync(exchange.Adapt<Storage.Inventory.Models.Exchange>(), token);
        await _inventoryDbContext.SaveChangesAsync(token);
    }

    public async Task EditAsync(Models.Exchange.Exchange exchange, CancellationToken token)
    {
        _inventoryDbContext.Exchanges.Update(exchange.Adapt<Storage.Inventory.Models.Exchange>());
        await _inventoryDbContext.SaveChangesAsync(token);
    }

    public async Task DownloadImageFromS3(Guid id, HttpResponse response, CancellationToken token)
    {
        var exchange = await GetByIdAsync(id, token);

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