using System.Text.Json.Serialization;
using Trader.Models.Clients.DeribitResponse;

namespace Trader.Client.Deribit.Models.Response;

public class ListOrderResponse
{
    [JsonPropertyName("result")] 
    public List<OrderResponseModel> Result { get; } = new();
}