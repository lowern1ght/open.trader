using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Trader.Configuration.Models;
using Trader.Helpers.Identity;
using Trader.Helpers.JwtToken;
using Trader.Identity.Service.Interfaces;
using Trader.Models.Identity;
using Trader.Models.Response;
using Trader.Storage.Account;
using Trader.Storage.Account.Models;

namespace Trader.Identity.Service;

public class IdentityService : IIdentityService<TraderUser>
{
    private readonly IdentityConfig _identityConfig;
    private readonly UserManager<TraderUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IdentityTraderDbContext _traderDbContext;

    public IdentityService(IHttpContextAccessor contextAccessor, UserManager<TraderUser> userManager, 
        IdentityConfig identityConfig, IdentityTraderDbContext traderDbContext)
    {
        _userManager = userManager;
        _identityConfig = identityConfig;
        _traderDbContext = traderDbContext;
        _contextAccessor = contextAccessor;
    }
    
    public async Task LogoutAsync(CancellationToken token)
    {
        if (_contextAccessor.HttpContext != null)
            await _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
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
        var traderUser = await _userManager.FindByEmailAsync(model.Email);

        if (traderUser is null)
        {
            throw new Exception($"User {model.Email} not found");
        }

        if (_contextAccessor.HttpContext is null)
        {
            throw new InvalidOperationException($"{nameof(_contextAccessor.HttpContext)} is null");
        }

        var claimsPrincipal = traderUser.ToClaimPrincipal();
        
        await _contextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claimsPrincipal);
        
        return await CreateIdentityTokenAsync(traderUser, token);
    }

    public async Task RegisterAsync(RegisterModel model, CancellationToken token)
    {
        var traderUsers = await _traderDbContext.Users.Where(traderUser 
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

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            throw new Exception(JsonSerializer.Serialize(result.Errors.ToArray()));
        }
    }

    public Task<TokenResult> CreateIdentityTokenAsync(TraderUser user, CancellationToken token)
    {
        var jwtToken = JwtTokenHelper.CreateToken(
            _identityConfig,
            user.ToClaimPrincipal());

        var tokenResult = new TokenResult
        {
            ValidTo = jwtToken.ValidTo,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtToken)
        };

        return Task.FromResult(tokenResult);
    }
}