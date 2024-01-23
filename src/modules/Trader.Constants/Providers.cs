using Trader.Constants.Attributes;

namespace Trader.Constants;

public class Providers
{
    /// <summary>
    /// www.deribit.com
    /// </summary>
    [Provider("deribit", "Deribit", "www.deribit.com", "deribit.svg")]
    public class Deribit
    {
        public const string Url = "www.deribit.com";
    }

    /// <summary>
    /// test.deribit.com
    /// </summary>
    [Provider("test-deribit", "Test deribit", "test.deribit.com", "deribit-test.svg")]
    public class TestDeribit
    {
        public const string Url = "test.deribit.com";
    }
}