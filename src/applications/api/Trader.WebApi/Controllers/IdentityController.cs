using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trader.Extensions.Others;
using Trader.Models.Identity;
using Trader.Storage.Account.Models;

namespace Trader.WebApi.Controllers;

[ApiController]
[Route("/[controller]/")]
public class IdentityController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public IdentityController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    /// <summary>
    ///     Login user
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginAsync(LoginEmailModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.ToData());

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user is null) return NotFound(nameof(model.Email));

        var result = await _signInManager.PasswordSignInAsync(user, model.Password,
            model.RememberMe, false);

        if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError);

        return Ok();
    }

    /// <summary>
    ///     Logout authorized user
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LogoutAsync()
    {
        try
        {
            await _signInManager.SignOutAsync();
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }

        return Ok();
    }

    /// <summary>
    ///     Register new user
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterAsync(RegisterEmailModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState.ToData());

        var emailAsync = await _userManager.FindByEmailAsync(model.Email);

        if (emailAsync is not null) return Problem($"{nameof(model.Email)} is exists");

        var nameAsync = await _userManager.FindByNameAsync(model.Username);

        if (nameAsync is not null) return Problem($"{nameof(model.Username)} is exists");

        var user = new User
        {
            Email = model.Email,
            UserName = model.Username
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        return !result.Succeeded
            ? Problem(JsonSerializer.Serialize(result.Errors.Select(error => error.Description)))
            : Ok();
    }

    /// <summary>
    ///     Get user info on front
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IActionResult> InfoAsync()
    {
        return Task.FromResult<IActionResult>(Json(HttpContext.User.Claims.ToData()));
    }
}