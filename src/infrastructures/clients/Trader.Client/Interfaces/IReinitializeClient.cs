using Trader.Models.Clients.Secret;

namespace Trader.Client.Interfaces;

public interface IReinitializeClient<in TAuthorizationModel>
    where TAuthorizationModel : ClientAuthorizationModel
{
    TimeSpan Duration { get; }
    DateTimeOffset LastUpdate { get; }

    bool NeedReinitialization(TimeSpan? duration)
    {
        return DateTimeOffset.Now - LastUpdate > (duration ?? Duration);
    }

    Task<HttpClient> ReinitializeClientAsync(TAuthorizationModel model, CancellationToken token);
}