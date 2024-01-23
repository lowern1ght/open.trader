using MongoDB.Bson.Serialization.Attributes;

namespace Trader.Storage.Settings.Models.Common;

public interface ITradingDescriptions
{
    [BsonRequired]
    public string InstrumentName { get; set; }
}