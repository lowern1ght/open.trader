namespace Trader.Constants.General;

public class Cookie
{
    /// <summary>
    ///     Name Identity(Auth) cookie in request | response
    /// </summary>
    public const string Identity = "_acc.trader";

    /// <summary>
    ///     Name Antiforgery cookie in request | response
    /// </summary>
    public const string Antiforgery = "_af.trader";
}