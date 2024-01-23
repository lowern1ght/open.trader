using Microsoft.EntityFrameworkCore;
using Trader.Storage.Inventory.Models;

namespace Trader.Storage.Inventory;

public sealed class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    public DbSet<DeribitSecret> DeribitSecrets { get; set; } = null!;
}