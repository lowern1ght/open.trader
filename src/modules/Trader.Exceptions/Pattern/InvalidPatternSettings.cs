namespace Trader.Exceptions.Pattern;

public class InvalidPatternSettings : Exception
{
    public InvalidPatternSettings(params object[] parameters)
        : base(string.Join(parameters.ToString(), ", ") + " invalid options") { }
}