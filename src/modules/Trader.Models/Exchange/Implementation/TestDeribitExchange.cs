using Trader.Models.Exchange.Attributes;
using Trader.Models.Exchange.Interfaces;
using static Trader.Constants.General.Exchanges;

namespace Trader.Models.Exchange.Implementation;

[ExchangeDescription(
    Name = TestDeribit.Name,
    BaseUrl = TestDeribit.BaseUrl,
    ResourceName = TestDeribit.ResourceName,
    DisplayName = TestDeribit.DisplayName)]
public class TestDeribitExchange : IExchangeDescription { }