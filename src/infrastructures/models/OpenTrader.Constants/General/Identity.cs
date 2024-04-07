namespace OpenTrader.Constants.General;

/// <summary>
///     Section for Identity modules
/// </summary>
public static class Identity
{
    private const string CookiePrefix = ".Trader";
    
    public static class Path
    {
        public const string LoginUrl = "/identity/login";
        public const string LogoutUrl = "/identity/logout";
    }
    
    public class Scheme
    {
        public const string TraderIdentity = "Identity" + CookiePrefix;
    }
}