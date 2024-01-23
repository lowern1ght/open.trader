namespace Trader.Futures.Core.Interfaces;

public interface IDirectionOrdersSettings
{
    public bool LongOrders { get; }
    
    public bool ShortOrders { get; }
}