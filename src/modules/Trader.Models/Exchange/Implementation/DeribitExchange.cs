using Trader.Models.Exchange.Attributes;
using Trader.Models.Exchange.Interfaces;
using static Trader.Constants.General.Exchanges;

namespace Trader.Models.Exchange.Implementation;

[ExchangeDescription(
    Name = Deribit.Name,
    BaseUrl = Deribit.BaseUrl,
    ResourceName = Deribit.ResourceName,
    DisplayName = Deribit.DisplayName)]
public class DeribitExchange : IExchangeDescription { }