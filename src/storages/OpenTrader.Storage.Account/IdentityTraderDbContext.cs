using Microsoft.EntityFrameworkCore;
using OpenTrader.Storage.Account.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OpenTrader.Storage.Account;

public sealed class IdentityTraderDbContext : IdentityDbContext<TraderUser>
{
    public IdentityTraderDbContext(DbContextOptions<IdentityTraderDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }
}