using Trader.Services.Clients.Models;

namespace Trader.Services.Clients.Interfaces;

public abstract class HttpClientLimiterBase
{
    protected TimeSpan DefaultWaitLock = TimeSpan.FromMilliseconds(100);
    protected HttpClientLimiterBase(LimiterSettings limiterSettings)
    {
        LimiterSettings = limiterSettings;
        ReaderWriterLockSlim = new ReaderWriterLockSlim();
    }

    protected LimiterSettings LimiterSettings { get; init; }
    protected ReaderWriterLockSlim ReaderWriterLockSlim { get; set; }
    
    public abstract Task<HttpResponseMessage> GetAsync(string url, CancellationToken token);
    public abstract Task<HttpResponseMessage> PostAsync(string url, object? body, CancellationToken token);
}