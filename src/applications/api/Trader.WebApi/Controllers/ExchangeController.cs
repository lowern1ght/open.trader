using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Trader.Constants.General;
using Trader.Exchange.Service.Interfaces;

namespace Trader.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("/[controller]/")]
[EnableCors(CorsPolicies.AllowAll)]
public class ExchangeController : Controller
{
    private readonly IExchangeService _exchangeService;
    private readonly IExchangeImageService _imageService;

    public ExchangeController(IExchangeService exchangeService, IExchangeImageService imageService)
    {
        _exchangeService = exchangeService;
        _imageService = imageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken token)
    {
        return Ok((await _exchangeService.CollectionAsync(token)).ToArray());
    }
    
    [HttpGet("{name}/image")]
    public async Task GetImageById(string name, CancellationToken token)
    {
        try
        {
            await _imageService.DownloadImageByName(name, token);
        }
        catch (Exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}