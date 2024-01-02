using Microsoft.Extensions.Logging;
using Trader.Futures.Core.Interfaces;

namespace Trader.Futures.Core.Clients;

public class DeribitHttpClient : IExchangeClient
{
    public DateTime LastRequest { get; init; } = DateTime.Now;
    public TimeSpan Duration { get; init; } = TimeSpan.FromSeconds(1);
    public int MaxRequestInTime { get; init; } = Constants.General.HttpClient.MaxRequestInTime;

    private readonly HttpClient _client;
    private readonly ILogger<DeribitHttpClient> _logger;

    public DeribitHttpClient(HttpClient client, ILogger<DeribitHttpClient> logger)
    {
        _client = client;
        _logger = logger;
    }
}