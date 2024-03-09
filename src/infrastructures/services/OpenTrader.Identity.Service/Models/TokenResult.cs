namespace OpenTrader.Identity.Service.Models;

public class TokenResult
{
    public DateTime ValidTo { get; set; }
    public required string Token { get; set; }
}