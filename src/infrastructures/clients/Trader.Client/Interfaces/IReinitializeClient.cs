using Trader.Models.Clients.Secret;

namespace Trader.Client.Interfaces;

public interface IReinitializeClient<in TAuthorizationModel>
    where TAuthorizationModel : ClientAuthorizationModel
{
    Task<HttpClient> ReinitializeClientAsync(TAuthorizationModel model, CancellationToken token);
}