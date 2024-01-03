using System.Linq.Expressions;

namespace Trader.Client.Interfaces;

public interface IRequestLimiter
{
    protected int MaxRequest { get; }
    protected int CurrentRequest { get; set; }
    
    Task<TResult> LimiterRequestAsync<TResult>(Expression<Func<TResult>> expression, CancellationToken token);
}