namespace OpenTrader.Pattern.Core.Models.Configuration;

public record BrokerSettings
{
    public required string Title { get; init; } = PatternDefault.Brokers.RabbitMq;
    
    public required string Username { get; init; }
    
    public required string Password { get; init; }
    
    public required ConnectionSettings ConnectionSettings { get; set; }
}