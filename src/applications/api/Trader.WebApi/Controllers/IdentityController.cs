using Microsoft.AspNetCore.Mvc;
using Trader.Storage.Account.Models;
using Microsoft.AspNetCore.Authorization;
using Trader.Identity.Service.Extensions;
using Trader.Identity.Service.Interfaces;
using Trader.Identity.Service.Models;

namespace Trader.WebApi.Controllers;

[ApiController]
[Route("/[controller]/")]
public class IdentityController : Controller
{
    private readonly ILogger<IdentityController> _logger;
    private readonly IIdentityService<TraderUser> _identityService;

    public IdentityController(IIdentityService<TraderUser> identityService, ILogger<IdentityController> logger)
    {
        _logger = logger;
        _identityService = identityService;
    }

    /// <summary>
    ///     Login user
    /// </summary>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginModel model, CancellationToken token)
    {
        if (!ModelState.IsValid) 
            return ValidationProblem(ModelState);

        try
        {
            return Ok(await _identityService.LoginAsync(model, token));
        }
        catch (Exception exception)
        {
            _logger.Log(LogLevel.Error, "Unhandled exception: {ExceptionMessage}", exception.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    ///     Logout authorized user
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> LogoutAsync(CancellationToken token)
    {
        await _identityService.LogoutAsync(token);
        return Ok();
    }

    /// <summary>
    ///     Register new user
    /// </summary>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterModel model, CancellationToken token)
    {
        if (!ModelState.IsValid) 
            return ValidationProblem(ModelState);

        try
        {
            await _identityService.RegisterAsync(model, token);
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }

        return Ok();
    }

    /// <summary>
    ///     Get user info on front
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize]
    public Task<IActionResult> InfoAsync()
    {
        return Task.FromResult<IActionResult>(Json(HttpContext.User.Claims.ToData()));
    }
}