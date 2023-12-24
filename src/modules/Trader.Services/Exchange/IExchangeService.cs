using Microsoft.AspNetCore.Http;

namespace Trader.Services.Exchange;

public interface IExchangeService
{
    Task DeleteAsync(Guid id, CancellationToken token);
    Task<Models.Exchange.Exchange> GetByIdAsync(Guid id, CancellationToken token);
    Task<Models.Exchange.Exchange> GetByNameAsync(string name, CancellationToken token);
    Task EditAsync(Models.Exchange.Exchange exchange, CancellationToken token);
    Task CreateAsync(Models.Exchange.Exchange exchange, CancellationToken token);
    Task<IEnumerable<Models.Exchange.Exchange>> CollectionAsync(CancellationToken token);
    public Task DownloadImageFromS3(Guid id, HttpResponse response, CancellationToken token);
}