using Trader.Attributes.Provider;

namespace Trader.Constants;

public class Providers
{
    /// <summary>
    /// www.deribit.com
    /// </summary>
    [ProviderDescription(UniqueName = "deribit", Title = "Deribit", BaseUrl = "www.deribit.com", ImageIdentification = "deribit.svg")]
    public class Deribit { public const string Url = "www.deribit.com"; }

    /// <summary>
    /// test.deribit.com
    /// </summary>
    [ProviderDescription(UniqueName = "test-deribit", Title = "Test deribit", BaseUrl = "test.deribit.com", ImageIdentification = "deribit-test.svg")]
    public class TestDeribit { }
}