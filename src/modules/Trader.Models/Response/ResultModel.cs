using System.Text.Json;

namespace Trader.Models.Response;

public class ResultModel
{
    public string Status { get; set; } = "Successes";
    public string? Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}