namespace Trader.Storage.Settings.Interfaces;

public interface IDatabaseOptions
{
    public string DatabaseName { get; }

    public string CollectionName { get; }

    public string ConnectionString { get; }
}