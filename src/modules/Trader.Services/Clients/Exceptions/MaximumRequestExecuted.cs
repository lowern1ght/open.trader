namespace Trader.Services.Clients.Exceptions;

public class MaximumRequestExecuted : Exception
{
    public MaximumRequestExecuted(int currentCount)
        : base($"Attempt execute request with current count: {currentCount}") { }
}