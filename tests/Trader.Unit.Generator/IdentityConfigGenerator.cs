using System.Text.Json;
using Xunit.Abstractions;
using IdentityServer4.Models;
using Trader.Extensions.Identity.Models;
using Identity = Trader.Constants.Identity;

namespace Trader.Unit.Generator;

public class IdentityConfigGenerator
{
    private readonly ITestOutputHelper _outputHelper;
    
    private JsonSerializerOptions SerializerOptions { get; }
    
    /// <summary>
    /// Developer config
    /// </summary>
    private IdentityConfig? DevIdentityConfig { get; set; }
    
    /// <summary>
    /// Production config 
    /// </summary>
    private IdentityConfig? ProductIdentityConfig { get; set; }
    
    public IdentityConfigGenerator(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        
        SerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }
    
    [Fact]
    public void DeveloperIdentityConfig()
    {
        var pathToConfig = ConfigFolderHelper.PathToIdentityConfig(configName: "identity.Development.json");
        
        DevIdentityConfig = new IdentityConfig
        {
            Clients = new List<Client>
            {
                new()
                {
                    ClientId = Identity.Clients.WebApi.Id,
                    Description = Identity.Clients.WebApi.Description,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret(SecretHelper.GenerateSha512())
                    },

                    AllowedScopes = { Identity.IdentityScopes.WebApi.Name }
                }
            },
            
            ApiScopes = new List<ApiScope>
            {
                new()
                {
                    Required = true,
                    Name = Identity.IdentityScopes.WebApi.Name,
                    Description = Identity.IdentityScopes.WebApi.Description,
                    DisplayName = Identity.IdentityScopes.WebApi.DisplayName
                }
            },
            
            IdentityResources = new List<IdentityResource>
            {
                new IdentityResources.OpenId()
            }
        };

        var data = JsonSerializer.Serialize(DevIdentityConfig, SerializerOptions);

        try
        {
            File.WriteAllText(pathToConfig, data.AddUpperRoot(nameof(IdentityConfig)));
        }
        catch (Exception exception)
        {
            Assert.Fail(exception.Message);
        }
        
        _outputHelper.WriteLine(data.Substring(0, 100) + "... save");
    }
    
    [Fact]
    public void ProductionIdentityConfig()
    {
        var pathToConfig = ConfigFolderHelper.PathToIdentityConfig(configName: "identity.json");
        
        ProductIdentityConfig = new IdentityConfig
        {
            Clients = new List<Client>
            {
                new()
                {
                    ClientId = Identity.Clients.WebApi.Id,
                    Description = Identity.Clients.WebApi.Description,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret(SecretHelper.GenerateSha512())
                    },

                    AllowedScopes = { Identity.IdentityScopes.WebApi.Name }
                }
            },
            
            ApiScopes = new List<ApiScope>
            {
                new()
                {
                    Required = true,
                    Name = Identity.IdentityScopes.WebApi.Name,
                    Description = Identity.IdentityScopes.WebApi.Description,
                    DisplayName = Identity.IdentityScopes.WebApi.DisplayName
                }
            },
            
            IdentityResources = new List<IdentityResource>
            {
                new IdentityResources.OpenId()
            }
        };

        var data = JsonSerializer.Serialize(ProductIdentityConfig, SerializerOptions);

        try
        {
            File.WriteAllText(pathToConfig, data.AddUpperRoot(nameof(IdentityConfig)));
        }
        catch (Exception exception)
        {
            Assert.Fail(exception.Message);
        }
        
        _outputHelper.WriteLine(data.Substring(0, 100) + "... save");
    }
}

internal static class ConfigFileHelper
{
    public static string AddUpperRoot(this string data, string nameProperty)
    {
        return "{" + $"\"{nameProperty}\"" + " : " + data + "}";
    }
}