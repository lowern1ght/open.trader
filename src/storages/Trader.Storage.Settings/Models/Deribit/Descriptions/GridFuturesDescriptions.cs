using MongoDB.Bson.Serialization.Attributes;
using Trader.Storage.Settings.Models.Common;

namespace Trader.Storage.Settings.Models.Deribit.Descriptions;

public class GridFuturesDescriptions : ITradingDescriptions
{
    [BsonRequired]
    public string InstrumentName { get; set; } = string.Empty;
    
    [BsonRequired]
    public int OrderSizeUsd { get; set; }
    
    [BsonRequired]
    public int MarginBetweenOrders { get; set; }
    
    [BsonRequired]
    public int DeviationFromСurrentPrice { get; set; }

    [BsonRequired]
    public int OrdersCount { get; set; }
}