namespace Trader.Configuration.Models;

public class S3Settings
{
    public required string Host { get; set; }
    public required string Key { get; set; }
    public required string Secret { get; set; }
}