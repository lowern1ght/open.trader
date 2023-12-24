using Trader.Constants.Models;

namespace Trader.Constants;

/// <summary>
///     Section for Identity modules
/// </summary>
public static class Identity
{
    public static class IdentityScopes
    {
        public static readonly IdentityScopeDescription WebApi = new()
        {
            Name = "web-api.trader",
            Description = "Web api scope",
            DisplayName = "Web-Api Scope"
        };

        public static readonly IdentityScopeDescription Universal = new()
        {
            Name = "universal.trader",
            Description = "Universal scope",
            DisplayName = "Universal Scope"
        };
    }

    public static class Clients
    {
        public static readonly ClientDescription WebApi = new()
        {
            Id = "web-api.trader",
            Description = "Web-Api default client"
        };

        public static readonly ClientDescription Universal = new()
        {
            Id = "universal.client",
            Description = "Universal client"
        };
    }

    public static class Path
    {
        public const string AccessesDenied = "/api/account";
        public const string LoginUrl = "/api/account/login";
        public const string LogoutUrl = "/api/account/logout";
    }
}