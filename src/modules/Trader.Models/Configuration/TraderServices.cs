namespace Trader.Models.Configuration;

public class TraderServices
{
    public Dictionary<string, string> Urls { get; init; } = new();
}

public class TraderServiceDescription
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}