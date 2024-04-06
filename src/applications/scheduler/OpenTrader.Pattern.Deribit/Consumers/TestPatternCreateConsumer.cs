using MassTransit;
using OpenTrader.Pattern.Core.Models.Contracts.Deribit;

namespace OpenTrader.Pattern.Deribit.Consumers;

public class TestPatternCreateConsumer(ILogger<TestPatternCreateConsumer> logger) : IConsumer<TestPatternCreate>
{
    public async Task Consume(ConsumeContext<TestPatternCreate> context)
    {
        logger.LogInformation("{Guid}, {Md5}", context.Message.Id, context.Message.Value);
        await Task.CompletedTask;
    }
}