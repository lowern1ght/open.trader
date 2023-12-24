using System.Security.Claims;
using Trader.Models.Identity;

namespace Trader.Extensions.Others;

public static class ClaimIdentityExtensions
{
    /// <summary>
    ///     Convert claims to View model
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static UserInfoModel ToData(this IEnumerable<Claim> claims)
    {
        claims = claims.ToArray();

        return new UserInfoModel
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