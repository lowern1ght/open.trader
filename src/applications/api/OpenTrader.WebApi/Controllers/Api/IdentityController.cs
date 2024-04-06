using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OpenTrader.Identity.Service.Exceptions;
using OpenTrader.Identity.Service.Extensions;
using OpenTrader.Identity.Service.Interfaces;
using OpenTrader.Identity.Service.Models;

namespace OpenTrader.WebApi.Controllers.Api;

/// <summary>
/// 
/// </summary>
/// <param name="identityService"></param>
/// <param name="logger"></param>
[ApiController]
[Route("~/api/v1/[controller]/")]
public class IdentityController(IIdentityService identityService, ILogger<IdentityController> logger) : Controller
{
    /// <summary> Login user with <c>Asp.Identity</c>> </summary>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <response code="200">Successes login with cookie</response>
    /// <response code="500">Unhandled exception</response>
    [AllowAnonymous, HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginModel model, CancellationToken token)
    {
        if (!ModelState.IsValid) 
            return ValidationProblem(ModelState);

        try
        {
            await identityService.LoginAsync(model, token);
        }
        catch (Exception exception)
        {
            logger.Log(LogLevel.Error, "Unhandled exception: {ExceptionMessage}", exception.Message);
            return Problem(exception.Message);
        }
        
        return Ok($"Successes login [{HttpContext.User.GetHashCode()}]");
    }
    
    /// <summary> Logout authorized user </summary>
    /// <response code="200">Successes generate token from <code>LoginModel</code></response>
    /// <response code="500">Unhandled exception</response>
    [Authorize, HttpPost("logout")]
    public async Task<IActionResult> LogoutAsync(CancellationToken token)
    {
        await identityService.LogoutAsync(token);
        return Ok();
    }

    /// <summary> Register new user </summary>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <response code="200">Create OpenTrader user from <code>RegisterModel</code></response>
    /// <response code="400">If data from create is not valid</response>
    /// <response code="500">Unhandled exception</response>
    [AllowAnonymous, HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model, CancellationToken token)
    {
        if (!ModelState.IsValid) 
            return ValidationProblem(ModelState);

        try
        {
            await identityService.RegisterAsync(model, token);
        }
        catch (InvalidCreateUser exception)
        {
            logger.Log(LogLevel.Information, exception.Message);
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            logger.Log(LogLevel.Error, "${Exception}", exception.Message);
            return Problem(exception.Message);
        }

        return Ok();
    }

    /// <summary> Get user info on front </summary>
    /// <returns><code>ClaimIdentity</code></returns>
    /// <response code="200">Return <c>ClaimIdentity</c> from <c>HttpContext</c>></response>
    /// <response code="500">Unhandled exception</response>
    [HttpGet, Authorize]
    public Task<IActionResult> InfoAsync()
    {
        return Task.FromResult<IActionResult>(Json(HttpContext.User.Claims.ToData()));
    }
    
    #region JwtToken

    /// <summary> Create JWT Token from Cookie Identity </summary>
    /// <param name="token"></param>
    /// <exception cref="NotImplementedException"></exception>
    [Authorize, HttpGet("token")]
    public async Task<IActionResult> TokenAsync(CancellationToken token)
    {
        try
        {
            return Ok(await identityService.JwtTokenFromClaimsAsync(HttpContext.User.Claims.ToData(), token));
        }
        catch (Exception exception)
        {
            logger.Log(LogLevel.Error, "{Exception}", exception.Message);
            return Problem(exception.Message);
        }
    }
    
    /// <summary> Create JWT token from user identity </summary>
    /// <param name="model"></param>
    /// <param name="token"></param>
    /// <response code="200">Successes generate token from <code>LoginModel</code></response>
    /// <response code="500">Unhandled exception</response>
    [AllowAnonymous, HttpPost("token")]
    public async Task<IActionResult> LoginTokenAsync([FromBody] LoginModel model, CancellationToken token)
    {
        try
        {
            return Ok(await identityService.JwtTokenAsync(model, token));
        }
        catch (Exception exception)
        {
            logger.Log(LogLevel.Error, "Unhandled exception: {ExceptionMessage}", exception.Message);
            return Problem(exception.Message);
        }
    }

    #endregion
}