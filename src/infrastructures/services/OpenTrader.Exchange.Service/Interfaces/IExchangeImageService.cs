using OpenTrader.Exchange.Service.Models;

namespace OpenTrader.Exchange.Service.Interfaces;

public interface IExchangeImageService
{
    Task<ImageResult> DownloadImageByName(string fileName, CancellationToken token);
}