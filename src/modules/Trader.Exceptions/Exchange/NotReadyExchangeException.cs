namespace Trader.Exceptions.Exchange;

public class NotReadyExchangeException : Exception
{
    public NotReadyExchangeException(string exchangeName)
        : base($"{exchangeName} is not ready") { }
}