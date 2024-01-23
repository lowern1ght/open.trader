using Trader.Enums.Settings;
using Trader.Storage.Settings.Interfaces;
using Trader.Storage.Settings.Models.Common;
using Trader.Storage.Settings.Models.Deribit.Descriptions;
using MongoDB.Bson.Serialization.Attributes;

namespace Trader.Storage.Settings.Models.Deribit;

public class GridFuturesSetting : PatternSetting, ITradingOptions, IStatusModel
{
    [BsonRequired]
    public bool ShortOrders { get; set; } = false;
    
    [BsonRequired]
    public bool LongOrders { get; set; } = false;
    
    [BsonIgnoreIfNull] 
    public ITradingDescriptions TradingDescriptions { get; init; } = new GridFuturesDescriptions();

    [BsonRequired] 
    public PatternStatus? Status { get; set; } = PatternStatus.Wait;
    
    [BsonRequired]
    public DateTimeOffset? LastStartTime { get; set; } = DateTimeOffset.Now;

    [BsonIgnoreIfNull]
    public TimeSpan? Duration { get; set; } = TimeSpan.FromSeconds(1);
}