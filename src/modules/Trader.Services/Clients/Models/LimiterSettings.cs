using HttpClient = Trader.Constants.General.HttpClient;

namespace Trader.Services.Clients.Models;

public class LimiterSettings
{
    public int CurrentRequestCount { get; } = 0;
    public TimeSpan Duration { get; init; } = HttpClient.DefaultDuration;
    public int MaxRequestInTime { get; init; } = HttpClient.MaxRequestInTime;
}