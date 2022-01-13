using MassTransit;
using ProducerService;

namespace SecondConsumer.Consumers;

public class WelcomeMessageWithAnotherClassNameConsumer : IConsumer<YouAreWelcomedEvent>
{
    public Task Consume(ConsumeContext<YouAreWelcomedEvent> context)
    {
        Console.WriteLine("Second WelcomeMessage Consumed");

        return Task.CompletedTask;
    }
}