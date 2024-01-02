using Microsoft.AspNetCore.Identity;

namespace Trader.Storage.Account.Models;

public class TraderUser : IdentityUser
{
    public bool UseIntegrationWithTelegram { get; set; }
}