using System.Security.Claims;
using Trader.Identity.Service.Models;

namespace Trader.Identity.Service.Extensions;

public static class ClaimIdentityExtensions
{
    /// <summary>
    ///     Convert claims to View model
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static UserModel ToData(this IEnumerable<Claim> claims)
    {
        claims = claims.ToArray();

        return new UserModel
        {
            Id = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)
                ?.Value ?? throw new InvalidOperationException(),
            Email = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)
                ?.Value ?? throw new InvalidOperationException(),
            Username = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value
                       ?? throw new InvalidOperationException()
        };
    }
}