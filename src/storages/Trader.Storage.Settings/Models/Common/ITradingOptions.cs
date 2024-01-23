using MongoDB.Bson.Serialization.Attributes;

namespace Trader.Storage.Settings.Models.Common;

public interface ITradingOptions
{
    [BsonIgnoreIfNull]
    public TimeSpan? Duration { get; }
}