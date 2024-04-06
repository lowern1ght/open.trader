using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using OpenTrader.Identity.Service.Models.Configuration;

namespace OpenTrader.Identity.Service.Helpers;

public class JwtTokenHelper
{
    /// <summary>
    /// Create Jwt token from ClaimPrincipal
    /// </summary>
    /// <param name="identityConfig"></param>
    /// <param name="claimsPrincipal"></param>
    /// <returns></returns>
    /// <exception cref="OperationCanceledException">if operation is canceled</exception>
    public static JwtSecurityToken CreateToken(IdentityConfig identityConfig, ClaimsPrincipal claimsPrincipal)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identityConfig.Key));
            
        return new JwtSecurityToken(
            issuer: identityConfig.Issuer,
            audience: identityConfig.Audience,
            expires: DateTime.Now.AddDays(30),
            claims: claimsPrincipal.Claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
    }
}