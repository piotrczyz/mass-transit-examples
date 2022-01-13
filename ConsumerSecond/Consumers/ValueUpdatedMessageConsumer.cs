using Consumer.Contracts;
using MassTransit;

namespace SecondConsumer.Consumers;

public class ValueUpdatedEventConsumer : IConsumer<ValueUpdatedEvent>
{
    public Task Consume(ConsumeContext<ValueUpdatedEvent> context)
    {
        Console.WriteLine("Value from another service consumer consumed");
        
        return Task.CompletedTask;
    }
}