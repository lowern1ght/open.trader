using System.Linq.Expressions;

namespace Trader.Futures.Core.Interfaces;

public interface IHttpClientLimiter
{
    public TimeSpan Duration { get; }
    public DateTime LastRequest { get; }
    public int MaxRequestInTime { get; }

    public Task<HttpRequestMessage> RequestWithLimitAsync(Expression<Task<HttpRequestMessage>> expression, CancellationToken token);
}