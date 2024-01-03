using Microsoft.Extensions.Logging;
using Trader.Client.Interfaces;
using Trader.Constants;
using Trader.Models.Clients.Secret;

namespace Trader.Client.Deribit;

public class DeribitClient : IExchangeClient<Providers.Deribit>, IReinitializeClient<ClientAuthorizationModel>
{
    private readonly ILogger<DeribitClient> _logger;
    
    public TimeSpan Duration { get; } = TimeSpan.FromHours(3);
    public DateTimeOffset LastUpdate { get; } = DateTimeOffset.Now;

    /// <summary>
    /// Re init client, sender to api deribit/test.deribit
    /// </summary>
    protected HttpClient Client { get; set; } = new();
    
    public DeribitClient(ILogger<DeribitClient> logger)
    {
        _logger = logger;
    }
    
    public async Task<HttpClient> CreateClientAsync(ClientAuthorizationModel authorizationModel, CancellationToken token) 
        => await ReinitializeClientAsync(authorizationModel, token);

    public async Task<HttpClient> ReinitializeClientAsync(ClientAuthorizationModel authorizationModel, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}