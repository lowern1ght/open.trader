using TextExtensions;

namespace OpenTrader.Constants.MessageBroker;

public static class ExchangeSection
{
    public static readonly string Test = "test-exchange";
    public static readonly string Deribit = nameof(Deribit).ToSnakeCase();
}