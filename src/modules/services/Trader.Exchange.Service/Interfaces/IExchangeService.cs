namespace Trader.Exchange.Service.Interfaces;

public interface IExchangeService
{
    Task<Models.Exchange> GetByIdAsync(Guid id, CancellationToken token);
    Task<Models.Exchange> GetByNameAsync(string name, CancellationToken token);
    Task<IEnumerable<Models.Exchange>> ListAsync(CancellationToken token);
}