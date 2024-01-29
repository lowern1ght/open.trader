using System.Text.Json;
using Xunit.Abstractions;
using Trader.Configuration.Models;

namespace Trader.Generator;

public class GenerateCommon
{
    private readonly ITestOutputHelper _outputHelper;

    public GenerateCommon(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void GenerateTraderServiceJson()
    {
        var traderConfig = new TraderServices();

        traderConfig.Urls.Add(nameof(Sections.Futures), "http://trader.futures/");
        traderConfig.Urls.Add(nameof(Sections.Options), "http://trader.options/");

        _outputHelper.WriteLine(JsonSerializer.Serialize(traderConfig));
    }
}