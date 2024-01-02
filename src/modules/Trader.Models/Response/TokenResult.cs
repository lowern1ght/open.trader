namespace Trader.Models.Response;

public class TokenResult
{
    public DateTime ValidTo { get; set; }
    public required string Token { get; set; }
}