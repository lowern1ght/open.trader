using Trader.Enums.Exchange;
using System.Text.Json.Serialization;

namespace Trader.Client.Deribit.Models.Response;

public class OrderResponseModel
{
    [JsonPropertyName("is_liquidation")]
    public bool IsLiquidation { get; set; }

    [JsonPropertyName("risk_reducing")]
    public bool RiskReducing { get; set; }

    [JsonPropertyName("order_type")]
    public OrderType OrderType { get; set; }

    [JsonPropertyName("contracts")]
    public decimal Contracts { get; set; }

    [JsonPropertyName("creation_timestamp")]
    public long CreationTimestamp { get; set; }

    [JsonPropertyName("order_state")]
    public OrderState OrderState { get; set; }

    [JsonPropertyName("average_price")]
    public decimal AveragePrice { get; set; }

    [JsonPropertyName("time_in_force")]
    public TimeInForce TimeInForce { get; set; }

    [JsonPropertyName("filled_amount")]
    public decimal FilledAmount { get; set; }

    [JsonPropertyName("max_show")]
    public decimal MaxShow { get; set; }

    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("reduce_only")]
    public bool ReduceOnly { get; set; }

    [JsonPropertyName("post_only")]
    public bool PostOnly { get; set; }

    [JsonPropertyName("last_update_timestamp")]
    public long LastUpdateTimestamp { get; set; }

    [JsonPropertyName("replaced")]
    public bool Replaced { get; set; }

    [JsonPropertyName("web")]
    public bool Web { get; set; }

    [JsonPropertyName("api")]
    public bool Api { get; set; }

    [JsonPropertyName("direction")]
    public OrderMethod Direction { get; set; }

    [JsonPropertyName("mmp")]
    public bool Mmp { get; set; }

    [JsonPropertyName("instrument_name")]
    public string? InstrumentName { get; set; }

    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }
}