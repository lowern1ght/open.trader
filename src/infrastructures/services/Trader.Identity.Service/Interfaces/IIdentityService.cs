using Microsoft.AspNetCore.Identity;
using Trader.Identity.Service.Models;

namespace Trader.Identity.Service.Interfaces;

public interface IIdentityService<in TUser>
    where TUser : IdentityUser
{
    Task LogoutAsync(CancellationToken token);
    Task RegisterAsync(RegisterModel model, CancellationToken token);
    Task<TokenResult> LoginAsync(LoginModel model, CancellationToken token);
    Task<TokenResult> CreateIdentityTokenAsync(TUser user, CancellationToken token);
}