using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace OpenTrader.WebApi.Controllers;

[ApiController, Route("/")]
public class IndexController : Controller
{
    [HttpGet]
    public Task<IActionResult> IndexAsync()
    {
        return Task.FromResult<IActionResult>(Ok(Assembly.GetExecutingAssembly().FullName));
    }
}