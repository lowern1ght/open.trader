namespace OpenTrader.Exchange.Service.Models.Configuration;

public class S3Settings
{
    public required string Host { get; set; }
    public required string Key { get; set; }
    public required string Secret { get; set; }
}