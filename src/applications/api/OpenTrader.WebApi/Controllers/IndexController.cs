using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace OpenTrader.WebApi.Controllers;

/// <inheritdoc />
[ApiController, Route("/")]
public class IndexController : Controller
{
    /// <summary> Return Assembly name </summary>
    [HttpGet]
    public Task<IActionResult> IndexAsync()
    {
        return Task.FromResult<IActionResult>(Ok(Assembly.GetExecutingAssembly().FullName));
    }
}