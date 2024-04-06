using MassTransit;
using MD5Hash;
using Microsoft.AspNetCore.Mvc;
using OpenTrader.Pattern.Core.Models.Contracts.Deribit;

namespace OpenTrader.PatternApi.Controllers.Exchanges;

/// <inheritdoc />
[ApiController, Route("~/api/v1/pattern/[controller]/")]
public class DeribitController(IPublishEndpoint publishEndpoint, ILogger<DeribitController> logger) : Controller
{
    public async Task<IActionResult> TestPatternAsync(CancellationToken token)
    {
        try
        {
            await publishEndpoint.Publish(
                new TestPatternCreate
                {
                    Id = Guid.NewGuid(),
                    Value = "test_pattern_create".GetMD5()
                },
                token);
        }
        catch (Exception exception)
        {
            logger.LogError("{Exception}", exception.Message);
            return Problem(exception.Message);
        }

        return Ok();
    }
}