using Trader.Storage.Inventory;
using Trader.IdentityProviders.Service.Models;
using Trader.IdentityProviders.Service.Interfaces;

namespace Trader.IdentityProviders.Service.Providers;

public class DeribitIdentityService : IProviderIdentityService
{
    private readonly InventoryDbContext _inventoryDbContext;

    public DeribitIdentityService(InventoryDbContext inventoryDbContext)
    {
        _inventoryDbContext = inventoryDbContext;
    }
    
    public Task<ProviderAuthorizationModel> GetAuthorizationSecretById(Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task UploadAuthorizationSecret(ProviderAuthorizationModel authorizationModel, Guid userId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProviderAuthorizationModel>> GetAuthorizationSecretsAsync(Guid userId, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}