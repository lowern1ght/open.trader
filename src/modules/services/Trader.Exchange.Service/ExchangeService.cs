using Mapster;
using Trader.Storage.Inventory;
using Microsoft.EntityFrameworkCore;
using Trader.Exchange.Service.Interfaces;

namespace Trader.Exchange.Service;

public class ExchangeService : IExchangeService
{
    private readonly InventoryDbContext _inventoryDbContext;

    public ExchangeService(InventoryDbContext inventoryDbContext)
    {
        _inventoryDbContext = inventoryDbContext;
    }
    
    /// <summary>
    /// Get exchange by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<Models.Exchange> GetByIdAsync(Guid id, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        var exchange = await _inventoryDbContext.Exchanges.FirstOrDefaultAsync(exchange => exchange.Id == id, token);
        if (exchange is null) throw new InvalidOperationException($"exchange by id: {id} not found");

        return exchange.Adapt<Models.Exchange>();
    }

    /// <summary>
    /// Get exchange by name
    /// </summary>
    /// <param name="name"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<Models.Exchange> GetByNameAsync(string name, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        var exchange = await _inventoryDbContext.Exchanges.FirstOrDefaultAsync(exchange => exchange.Name == name, token);
        if (exchange is null) throw new InvalidOperationException($"exchange by name: {name} not found");

        return exchange.Adapt<Models.Exchange>();
    }

    /// <summary>
    /// Get all exchanges
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Models.Exchange>> ListAsync(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        return (await _inventoryDbContext.Exchanges.ToArrayAsync(token))
            .Adapt<IEnumerable<Models.Exchange>>();
    }
}