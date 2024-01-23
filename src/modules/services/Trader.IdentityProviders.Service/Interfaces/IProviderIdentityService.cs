using Trader.IdentityProviders.Service.Models;

namespace Trader.IdentityProviders.Service.Interfaces;

public interface IProviderIdentityService
{
    Task<ProviderAuthorizationModel> GetAuthorizationSecretById(Guid id, CancellationToken token);
    
    Task UploadAuthorizationSecret(ProviderAuthorizationModel authorizationModel, Guid userId, CancellationToken token);
    
    Task<IEnumerable<ProviderAuthorizationModel>> GetAuthorizationSecretsAsync(Guid userId, CancellationToken token);
}