using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OpenTrader.Constants.General;
using OpenTrader.Exchange.Service.Interfaces;

namespace OpenTrader.WebApi.Controllers.Api;

[Authorize]
[ApiController]
[Route("~/api/v1/[controller]/")]
[EnableCors(CorsPolicies.AllowAll)]
public class ExchangeController(IExchangeService exchangeService, IExchangeImageService imageService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken token)
    {
        return Ok((await exchangeService.CollectionAsync(token)).ToArray());
    }
    
    [HttpGet("{name}/image")]
    public async Task GetImageById(string name, CancellationToken token)
    {
        try
        {
            await imageService.DownloadImageByName(name, token);
        }
        catch (Exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}