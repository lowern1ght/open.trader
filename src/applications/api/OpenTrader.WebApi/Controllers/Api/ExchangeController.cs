using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OpenTrader.Constants.General;
using Microsoft.AspNetCore.Authorization;
using OpenTrader.Exchange.Service.Interfaces;

namespace OpenTrader.WebApi.Controllers.Api;

/// <summary> Controller work with exchanges </summary>
/// <param name="logger"></param>
/// <param name="exchangeService"></param>
[Authorize, ApiController]
[Route("~/api/v1/[controller]/")]
[EnableCors(CorsPolicies.AllowAll)]
public class ExchangeController(ILogger<ExchangeController> logger, IExchangeService exchangeService) : Controller
{
    /// <summary> </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    [Authorize, HttpGet]
    [ResponseCache(Duration = 1200, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> ListAsync(CancellationToken token)
    {
        try
        {
            return Ok((await exchangeService.ListAsync(token)).ToArray());
        }
        catch (Exception exception)
        {
            logger.LogError("{Message}", exception.Message);
            return Problem(exception.Message);
        }
    }
}