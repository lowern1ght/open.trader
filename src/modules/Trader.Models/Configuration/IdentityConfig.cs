namespace Trader.Models.Configuration;

public class IdentityConfig
{
    public required string Key { get; init; } = string.Empty;
    public required string Issuer { get; init; } = string.Empty;
    public required string Audience { get; init; } = string.Empty;
}