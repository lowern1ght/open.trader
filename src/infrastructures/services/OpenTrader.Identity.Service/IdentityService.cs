using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenTrader.Identity.Service.Exceptions;
using OpenTrader.Identity.Service.Extensions;
using OpenTrader.Identity.Service.Helpers;
using OpenTrader.Identity.Service.Interfaces;
using OpenTrader.Identity.Service.Models;
using OpenTrader.Identity.Service.Models.Configuration;
using OpenTrader.Storage.Account;
using OpenTrader.Storage.Account.Models;

namespace OpenTrader.Identity.Service;

public class IdentityService(
    IHttpContextAccessor contextAccessor,
    UserManager<TraderUser> userManager,
    IdentityConfig identityConfig,
    IdentityTraderDbContext traderDbContext)
    : IIdentityService
{
    public async Task LogoutAsync(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        
        if (contextAccessor.HttpContext != null)
            await contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    /// <summary> Info <code>UserModel</code> from Cookie, JWT Token is <code>NotImplemented</code>> </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public Task<UserModel> InfoAsync(CancellationToken token)
    {
        return Task.FromResult(contextAccessor.HttpContext?.User.Claims.ToData() 
                               ?? throw new InvalidOperationException($"Claims empty"));
    }

    /// <summary>
    /// Login this HttpContext with default TraderScheme 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task LoginAsync(LoginModel model, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        
        var traderUser = await userManager.FindByEmailAsync(model.Email);

        if (traderUser is null)
            throw new Exception($"User with email: [{model.Email}] not found");

        if (contextAccessor.HttpContext is null)
            throw new InvalidOperationException($"{nameof(contextAccessor.HttpContext)} is null");

        var claimsPrincipal = traderUser.ToClaimPrincipal();

        var properties = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.Now.AddYears(1)
        };
        
        await contextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claimsPrincipal, properties);
    }

    /// <summary> Create user from <code>RegisterModel</code>> </summary>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <exception cref="InvalidCreateUser"></exception>
    public async Task RegisterAsync(RegisterModel model, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        
        var traderUsers = await traderDbContext.Users.Where(traderUser 
                => traderUser.UserName == model.Username || 
                   traderUser.Email == model.Email)
            .ToArrayAsync(cancellationToken: token);

        if (traderUsers.Length != 0)
            throw new Exception($"{model.Email}, {model.Username} is exists in application");
        
        var user = new TraderUser
        {
            Email = model.Email,
            UserName = model.Username
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            throw new InvalidCreateUser(result.Errors.ToArray());
    }

    public async Task<TokenResult> JwtTokenAsync(LoginModel model, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        
        var traderUser = await userManager.FindByEmailAsync(model.Email);

        if (traderUser is null)
            throw new Exception($"User {model.Email} not found");
        
        return await CreateIdentityTokenAsync(traderUser);
    }

    public async Task<TokenResult> JwtTokenFromClaimsAsync(UserModel model, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        
        var traderUser = await userManager.FindByEmailAsync(model.Email);

        if (traderUser is null)
            throw new Exception($"User {model.Email} not found");
        
        return await CreateIdentityTokenAsync(traderUser);
    }

    private Task<TokenResult> CreateIdentityTokenAsync(TraderUser user)
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