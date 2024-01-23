using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Trader.Storage.Settings.Models.Common;

public class PatternSetting
{
    [BsonId]
    public required ObjectId Id { get; init; }
}