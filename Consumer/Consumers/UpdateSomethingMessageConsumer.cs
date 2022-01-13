using Consumer.Contracts;
using MassTransit;
using ProducerService;

namespace Consumer.Consumers;

public class UpdateSomethingMessageConsumer : IConsumer<UpdateSomethingCommand>
{
    public Task Consume(ConsumeContext<UpdateSomethingCommand> context)
    {
        Console.WriteLine($"Do staff: {context.Message.Value}");

        context.Publish(new ValueUpdatedEvent());
        
        return Task.CompletedTask;
    }
}