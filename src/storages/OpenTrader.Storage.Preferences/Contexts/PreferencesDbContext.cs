using Microsoft.EntityFrameworkCore;
using OpenTrader.Storage.Preferences.Models.Abstracts;

namespace OpenTrader.Storage.Preferences.Contexts;

public class PreferencesDbContext(DbContextOptions<PreferencesDbContext> options) : DbContext(options)
{
    public DbSet<PreferencesBase> Preferences { get; set; } = null!;
}