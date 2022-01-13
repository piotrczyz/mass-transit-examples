using MassTransit;
using ProducerService;

namespace Consumer.Consumers;

public class WelcomeMessageConsumer : IConsumer<YouAreWelcomedEvent>
{
    public Task Consume(ConsumeContext<YouAreWelcomedEvent> context)
    {
        Console.WriteLine("WelcomeMessage Consumed");

        return Task.CompletedTask;
    }
} 