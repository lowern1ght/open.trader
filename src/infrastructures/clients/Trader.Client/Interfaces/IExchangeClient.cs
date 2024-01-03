using Trader.Models.Clients.Secret;

namespace Trader.Client.Interfaces;

public interface IExchangeClient<TProvider>
    where TProvider : class
{
    public Task<HttpClient> CreateClientAsync(ClientAuthorizationModel authorizationModel, CancellationToken token);
}