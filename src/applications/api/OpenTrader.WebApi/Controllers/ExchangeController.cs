using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using OpenTrader.Constants.General;
using OpenTrader.Exchange.Service.Interfaces;

namespace OpenTrader.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("/[controller]/")]
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