using Microsoft.EntityFrameworkCore;

namespace Trader.Storage.Futures;

public class FuturesDbContext : DbContext
{
    public FuturesDbContext(DbContextOptions<FuturesDbContext> options)
        : base(options)
    {
    }
}