namespace Trader.Constants.General;

/// <summary>
///     Section for Identity modules
/// </summary>
public static class Identity
{
    public const string CookiePrefix = ".Trader";

    public class Query
    {
        public const string ReturnUrl = "returnUrl";
    }
    
    public static class Path
    {
        public const string AccessesDenied = "/identity";
        public const string LoginUrl = "/identity/login";
        public const string LogoutUrl = "/identity/logout";
    }
    
    public class Scheme
    {
        public const string TraderIdentity = "Identity" + CookiePrefix;
    }
}