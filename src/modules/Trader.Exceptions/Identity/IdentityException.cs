namespace Trader.Exceptions.Identity;

public class IdentityException : Exception
{
    public IdentityException(string reason)
        : base($"Identity error with reason: {reason}")
    {
        
    }
}