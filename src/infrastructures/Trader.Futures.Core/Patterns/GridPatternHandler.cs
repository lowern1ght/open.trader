using Trader.Futures.Core.Interfaces;
using Trader.Pattern.Attributes;
using Trader.Pattern.Interfaces;
using Trader.Futures.Core.Models;

namespace Trader.Futures.Core.Patterns;

[PatternDescription(Name = nameof(GridPatternHandler), Description = "Futures grid trading template")]
public class GridPatternHandler : IPatternHandler<GridSettings>
{
    private readonly IGridPatternService _gridPatternService;

    public GridPatternHandler(IGridPatternService gridPatternService)
    {
        _gridPatternService = gridPatternService;
    }
    
    public async Task Execute(GridSettings settings, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (settings.LongOrders)
            {
                await _gridPatternService.HandleLongOrders(settings.TradingDescription, token);
            }
            
            if (settings.ShortOrders)
            {
                await _gridPatternService.HandleShortOrders(settings.TradingDescription, token);
            }
        }
    }
}