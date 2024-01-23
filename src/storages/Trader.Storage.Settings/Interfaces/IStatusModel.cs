using MongoDB.Bson.Serialization.Attributes;
using Trader.Enums.Settings;

namespace Trader.Storage.Settings.Interfaces;

public interface IStatusModel
{
    [BsonIgnoreIfNull] 
    public PatternStatus? Status { get; }
    
    [BsonIgnoreIfNull]
    public DateTimeOffset? LastStartTime { get; }
}