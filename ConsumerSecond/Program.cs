using MassTransit;
using Messaging;
using SecondConsumer.Consumers;

var builder = WebApplication.CreateBuilder(args);

var azureServiceBus = builder.Configuration.GetSection("Azure:ServiceBus").Get<AzureServiceBusConfiguration>();

builder.Services.ConfigureMassTransit(azureServiceBus.ConnectionString, (context, configurator) =>
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