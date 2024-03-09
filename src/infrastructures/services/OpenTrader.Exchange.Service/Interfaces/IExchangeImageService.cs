namespace OpenTrader.Exchange.Service.Interfaces;

public interface IExchangeImageService
{
    Task DownloadImageByName(string fileName, CancellationToken token);
}