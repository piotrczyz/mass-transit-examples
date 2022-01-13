using Consumer.Consumers;
using GreenPipes;
using MassTransit;
using Messaging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureMassTransit((context, configurator) =>
{
    configurator.ReceiveEndpoint(QueueNames.CONSUMER_SERVICE_QUEUE, cfg =>
    {
        cfg.Consumer<WelcomeMessageConsumer>(context);
        cfg.Consumer<UpdateSomethingMessageConsumer>(context);
    });
});

var app = builder.Build();

app.MapGet("/", () => "Consumer started!");
app.Run();

