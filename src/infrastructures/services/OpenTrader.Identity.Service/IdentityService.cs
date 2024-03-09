using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenTrader.Identity.Service.Extensions;
using OpenTrader.Identity.Service.Helpers;
using OpenTrader.Identity.Service.Interfaces;
using OpenTrader.Identity.Service.Models;
using OpenTrader.Identity.Service.Models.Configuration;
using Trader.Storage.Account;
using Trader.Storage.Account.Models;

namespace OpenTrader.Identity.Service;

public class IdentityService(
    IHttpContextAccessor contextAccessor,
    UserManager<TraderUser> userManager,
    IdentityConfig identityConfig,
    IdentityTraderDbContext traderDbContext)
    : IIdentityService<TraderUser>
{
    public async Task LogoutAsync(CancellationToken token)
    {
        if (contextAccessor.HttpContext != null)
            await contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
    
    /// <summary>
    /// Login this HttpContext with default TraderScheme 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<TokenResult> LoginAsync(LoginModel model, CancellationToken token)
    {
        var traderUser = await userManager.FindByEmailAsync(model.Email);

        if (traderUser is null)
        {
            throw new Exception($"User {model.Email} not found");
        }

        if (contextAccessor.HttpContext is null)
        {
            throw new InvalidOperationException($"{nameof(contextAccessor.HttpContext)} is null");
        }

        var claimsPrincipal = traderUser.ToClaimPrincipal();
        
        await contextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claimsPrincipal);
        
        return await CreateIdentityTokenAsync(traderUser, token);
    }

    public async Task RegisterAsync(RegisterModel model, CancellationToken token)
    {
        var traderUsers = await traderDbContext.Users.Where(traderUser 
                => traderUser.UserName == model.Username || 
                   traderUser.Email == model.Email)
            .ToArrayAsync(cancellationToken: token);

        if (traderUsers.Length != 0)
        {
            throw new Exception($"{model.Email}, {model.Username} is exists in application");
        }
        
        var user = new TraderUser
        {
            Email = model.Email,
            UserName = model.Username
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            throw new Exception(JsonSerializer.Serialize(result.Errors.ToArray()));
        }
    }

    public Task<TokenResult> CreateIdentityTokenAsync(TraderUser user, CancellationToken token)
    {
        var jwtToken = JwtTokenHelper.CreateToken(
            identityConfig,
            user.ToClaimPrincipal());

        var tokenResult = new TokenResult
        {
            ValidTo = jwtToken.ValidTo,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtToken)
        };

        return Task.FromResult(tokenResult);
    }
}