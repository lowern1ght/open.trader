using Microsoft.EntityFrameworkCore;
using Trader.Storage.Account.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Trader.Storage.Account;

public sealed class IdentityTraderDbContext : IdentityDbContext<User>
{
    public IdentityTraderDbContext(DbContextOptions<IdentityTraderDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }
}