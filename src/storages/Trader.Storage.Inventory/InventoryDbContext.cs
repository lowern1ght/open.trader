using System.Reflection;
using System.Text.Json;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Trader.Models.Exchange.Attributes;
using Trader.Models.Exchange.Interfaces;
using Trader.Storage.Inventory.Models;

namespace Trader.Storage.Inventory;

public sealed class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    public DbSet<Exchange> Exchanges { get; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var exchangesDescriptions = new List<Exchange>();

        var assembly = Assembly.GetAssembly(typeof(ExchangeDescriptionAttribute));

        if (assembly is null)
        {
            throw new InvalidOperationException($"{nameof(assembly)} is null");
        }
        
        foreach (var type in assembly.GetTypes())
        {
            if (type.IsAssignableTo(typeof(IExchangeDescription)) && 
                type.GetCustomAttribute<ExchangeDescriptionAttribute>() is {} descriptionAttribute)
            {
                exchangesDescriptions.Add(descriptionAttribute.Adapt<Exchange>());
            }
        }

        Console.WriteLine(JsonSerializer.Serialize(exchangesDescriptions));
        
        modelBuilder
            .Entity<Exchange>()
            .HasKey(exchange => exchange.Id);
            
        modelBuilder.Entity<Exchange>()
            .HasData(exchangesDescriptions);
    }
}