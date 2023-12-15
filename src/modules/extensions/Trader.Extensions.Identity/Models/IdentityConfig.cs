using IdentityServer4.Test;
using IdentityServer4.Models;

namespace Trader.Extensions.Identity.Models;

[Serializable]
public class IdentityConfig
{
    /// <summary>
    ///     Test users
    /// </summary>
    public List<TestUser> TestClient { get; init; } = new();
    
    /// <summary>
    ///     Clients settings
    /// </summary>
    public IEnumerable<Client> Clients { get; init; } = ArraySegment<Client>.Empty;
    
    /// <summary>
    ///     Api scopes
    /// </summary>
    public IEnumerable<ApiScope> ApiScopes { get; init; } = ArraySegment<ApiScope>.Empty;
    
    /// <summary>
    /// Api resources
    /// </summary>
    public IEnumerable<ApiResource> ApiResources { get; init; } = ArraySegment<ApiResource>.Empty;
    
    /// <summary>
    ///  Identity Resources
    /// </summary>
    public IEnumerable<IdentityResource> IdentityResources { get; init; } = ArraySegment<IdentityResource>.Empty;
}