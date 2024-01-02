using Trader.Services.Clients.Models;
using Trader.Services.Clients.Exceptions;
using Trader.Services.Clients.Interfaces;

namespace Trader.Services.Clients;

public class HttpClientLimiter : HttpClientLimiterBase
{
    private readonly HttpClient _httpClient;
    
    public HttpClientLimiter(HttpClient httpClient, LimiterSettings limiterSettings) 
        : base(limiterSettings)
    {
        _httpClient = httpClient;
    }

    public override async Task<HttpResponseMessage> GetAsync(string url, CancellationToken token)
    {
        ReaderWriterLockSlim.TryEnterWriteLock(DefaultWaitLock);
        try
        {
            if (LimiterSettings.CurrentRequestCount < LimiterSettings.MaxRequestInTime)
            {
                return await _httpClient.GetAsync(url, token);
            }
            else
            {
                throw new MaximumRequestExecuted(LimiterSettings.CurrentRequestCount);
            }
        }
        finally
        {
            ReaderWriterLockSlim.ExitWriteLock();
        }
    }

    [Obsolete($"{nameof(NotImplementedException)}")]
    public override Task<HttpResponseMessage> PostAsync(string url, object? body, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}