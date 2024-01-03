using Microsoft.EntityFrameworkCore;

namespace Trader.Storage.Inventory;

public sealed class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }
}