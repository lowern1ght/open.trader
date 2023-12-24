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

    public DbSet<Exchange> Exchanges { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var defaultExchanges = new List<Exchange>
        {
            new()
            {
                Id = Guid.NewGuid(), 
                Title = "deribit", 
                BaseUrl = "www.deribit.com", 
                ResourceName = "deribit.svg"
            },
            
            new()
            {
                Id = Guid.NewGuid(),
                Title = "test-deribit",
                BaseUrl = "test.deribit.com", 
                ResourceName = "deribit-test.svg"
            }
        };

        modelBuilder
            .Entity<Exchange>()
            .HasData(defaultExchanges);
    }
}