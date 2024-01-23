using Trader.Storage.Settings.Interfaces;

namespace Trader.Storage.Settings.Options;

public class SettingsDatabaseOptions : IDatabaseOptions
{
    public required string DatabaseName { get; set; }
    public required string CollectionName { get; set; }
    public required string ConnectionString { get; set; }
}