using Microsoft.AspNetCore.Identity;
using OpenTrader.Identity.Service.Models;

namespace OpenTrader.Identity.Service.Interfaces;

public interface IIdentityService<in TUser>
    where TUser : IdentityUser
{
    Task LogoutAsync(CancellationToken token);
    Task RegisterAsync(RegisterModel model, CancellationToken token);
    Task<TokenResult> LoginAsync(LoginModel model, CancellationToken token);
    Task<TokenResult> CreateIdentityTokenAsync(TUser user, CancellationToken token);
}