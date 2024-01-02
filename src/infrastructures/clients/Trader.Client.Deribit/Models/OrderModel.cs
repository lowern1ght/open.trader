using Trader.Enums.Exchange;
using Trader.Helpers.Orders;
using System.Text.Json.Serialization;

namespace Trader.Client.Deribit.Models;

public class OrderModel
{
    public string? Id { get; set; }

    public string Label { get; set; } = LabelHelper.GenerateOrderLabel();
    
    public decimal Amount { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal LastPrice { get; set; }
    
    [JsonPropertyName("direction")]
    public OrderMethod Type { get; set; }
}