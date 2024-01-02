using System.Text.Json;
using Trader.Helpers.Exchange;
using Xunit.Abstractions;

namespace Trader.Storage.Tests;

public class InventoryStorageShould
{
    private readonly ITestOutputHelper _outputHelper;

    public InventoryStorageShould(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void AssemblyGetDescriptionTests()
    {

        var description = ExchangeHelper.GetExchangesDescription();
        
        _outputHelper.WriteLine(JsonSerializer.Serialize(description));
    }
}