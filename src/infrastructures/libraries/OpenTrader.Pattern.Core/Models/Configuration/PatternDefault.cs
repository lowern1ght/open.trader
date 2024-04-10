namespace OpenTrader.Pattern.Core.Models.Configuration;

public static class PatternDefault
{
    public class Brokers
    {
        public const string Kafka = nameof(Kafka);
        
        public const string RabbitMq = nameof(RabbitMq);
        
        [Obsolete($"NotImplemented")]
        public const string Postgres = nameof(Postgres);
    }
}