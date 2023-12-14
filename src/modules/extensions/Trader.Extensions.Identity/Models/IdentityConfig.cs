using Duende.IdentityServer.Test;
using Duende.IdentityServer.Models;

namespace Trader.Extensions.Identity.Models;

[Serializable]
public class IdentityConfig
{
    /// <summary>
    ///     Clients settings
    /// </summary>
    public IEnumerable<Client> Clients { get; init; } = ArraySegment<Client>.Empty;
    
    /// <summary>
    ///     Api scopes
    /// </summary>
    public IEnumerable<ApiScope> ApiScopes { get; init; } = ArraySegment<ApiScope>.Empty;
    
    /// <summary>
    ///     Test users
    /// </summary>
    public IEnumerable<TestUser> TestClient { get; init; } = ArraySegment<TestUser>.Empty;
    
    /// <summary>
    ///     Resources
    /// </summary>
    public IEnumerable<IdentityResource> IdentityResources { get; init; } = ArraySegment<IdentityResource>.Empty;
}