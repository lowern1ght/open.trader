using Trader.Models.Common;

namespace Trader.Models.Clients.Secret;

public class ClientAuthorizationModel : GuidModel
{
    public required string Key { get; set; }
    public required string Secret { get; set; }
}