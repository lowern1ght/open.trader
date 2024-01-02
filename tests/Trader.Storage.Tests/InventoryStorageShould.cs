using System.Text.Json;
using Xunit.Abstractions;
using Trader.Helpers.Exchange;

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