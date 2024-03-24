using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTrader.Identity.Service.Extensions;
using OpenTrader.Identity.Service.Interfaces;
using OpenTrader.Identity.Service.Models;
using OpenTrader.Storage.Account.Models;

namespace OpenTrader.WebApi.Controllers.Api;

[ApiController]
[Route("~/api/v1/[controller]/")]
public class IdentityController(IIdentityService<TraderUser> identityService, ILogger<IdentityController> logger) : Controller
{
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
            return Ok(await identityService.LoginAsync(model, token));
        }
        catch (Exception exception)
        {
            logger.Log(LogLevel.Error, "Unhandled exception: {ExceptionMessage}", exception.Message);
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
        await identityService.LogoutAsync(token);
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
            await identityService.RegisterAsync(model, token);
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