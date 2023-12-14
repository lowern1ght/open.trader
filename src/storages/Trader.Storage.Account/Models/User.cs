using Microsoft.AspNetCore.Identity;

namespace Trader.Storage.Account.Models;

public class User : IdentityUser
{
    public bool UseIntegrationWithTelegram { get; set; } = false;
}