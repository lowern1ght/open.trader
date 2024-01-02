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
        return Ok((await _exchangeService.ListAsync(token)).ToArray());
    }

    [HttpGet("id={id:guid}")]
    public async Task<IActionResult> FindAsync([FromQuery] Guid id, CancellationToken token)
    {
        return Ok(await _exchangeService.GetByIdAsync(id, token));
    }
    
    [HttpGet("name={name}")]
    public async Task<IActionResult> FindAsync([FromQuery] string name, CancellationToken token)
    {
        return Ok(await _exchangeService.GetByNameAsync(name, token));
    }
    

    
    [HttpGet("{id:guid}/image")]
    public async Task GetImageById(Guid id, CancellationToken token)
    {
        try
        {
            await _imageService.DownloadImageById(id, token);
        }
        catch (Exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}