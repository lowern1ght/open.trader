using System.Security.Claims;
using Trader.Storage.Account.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Trader.Helpers.Identity;

public static class TraderUserHelper
{
    /// <summary>
    ///     Convert traderUser to claim principal
    /// </summary>
    /// <param name="traderUser"></param>
    /// <exception cref="Exception"></exception>
    /// <returns></returns>
    public static ClaimsPrincipal ToClaimPrincipal(this TraderUser traderUser)
    {
        if (traderUser is { UserName: null } or { Email: null } or { Id: null })
        {
            throw new Exception($"user data is not valid");
        }
        
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme)
        {
            Label = traderUser.UserName
        };
        
        var claims = new List<Claim>
        {
            new (ClaimTypes.Email, traderUser.Email),
            new (ClaimTypes.Name, traderUser.UserName),
            new (ClaimTypes.NameIdentifier, traderUser.Id)
        };
        
        identity.AddClaims(claims);
        
        return new ClaimsPrincipal(identity);
    }
}