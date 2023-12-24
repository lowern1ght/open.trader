using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trader.Models.Exchange;
using Trader.Services.Exchange;

namespace Trader.WebApi.Controllers;

[ApiController]
[Route("/[controller]/")]
public class ExchangeController : Controller
{
    private readonly IExchangeService _exchangeService;

    public ExchangeController(IExchangeService exchangeService)
    {
        _exchangeService = exchangeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken token)
    {
        return Ok((await _exchangeService.CollectionAsync(token)).ToArray());
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
    
    [HttpGet("{id:guid}/description")]
    public async Task<IActionResult> DescriptionAsync([FromQuery] Guid id, CancellationToken token)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{name}/description")]
    public async Task<IActionResult> DescriptionAsync([FromQuery] string name, CancellationToken token)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{id}/image")]
    public async Task GetImageById(Guid id, CancellationToken token)
    {
        try
        {
            await _exchangeService.DownloadImageFromS3(id, Response, token);
        }
        catch (Exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }

    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromBody] Exchange exchange, CancellationToken token)
    {
        await _exchangeService.CreateAsync(exchange, token);
        return Ok();
    }

    [HttpPost("delete")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid id, CancellationToken token)
    {
        await _exchangeService.DeleteAsync(id, token);
        return Ok();
    }

    [HttpPost("edit")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditAsync([FromBody] Exchange exchange, CancellationToken token)
    {
        await _exchangeService.EditAsync(exchange, token);
        return Ok();
    }
}