using Microsoft.AspNetCore.Identity;

namespace OpenTrader.Storage.Account.Models;

public class TraderUser : IdentityUser
{
    public bool UseIntegrationWithTelegram { get; set; }
}