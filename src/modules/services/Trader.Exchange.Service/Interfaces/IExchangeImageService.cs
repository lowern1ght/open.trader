namespace Trader.Exchange.Service.Interfaces;

public interface IExchangeImageService
{
    Task DownloadImageById(Guid id, CancellationToken token);
}