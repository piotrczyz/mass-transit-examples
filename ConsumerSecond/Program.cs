using MassTransit;
using Messaging;
using SecondConsumer.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureMassTransit((context, configurator) =>
{
    configurator.ReceiveEndpoint(QueueNames.SECOND_CONSUMER_SERVICE_QUEUE, cfg =>
    {
        cfg.Consumer<WelcomeMessageWithAnotherClassNameConsumer>(context);
        cfg.Consumer<ValueUpdatedEventConsumer>(context);
    });
});

var app = builder.Build();

app.MapGet("/", () => "Second Consumer started!");
app.Run();