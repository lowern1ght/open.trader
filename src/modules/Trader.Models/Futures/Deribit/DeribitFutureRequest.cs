using Trader.Models.Futures.Interfaces;

namespace Trader.Models.Futures.Deribit;

public class DeribitFutureRequest : IFutureRequest
{
    public required string InstrumentName { get; set; }

    public int OrderSizeUsd { get; set; }
    public int MarginBetweenOrders { get; set; }
    public int DeviationFromСurrentPrice { get; set; }
    public int OrdersCount { get; set; }

    public bool ShortOrders { get; set; } = false;
    public bool LongOrders { get; set; } = false;

    public int MaxSummaryOrdersInPosition { get; set; }
}