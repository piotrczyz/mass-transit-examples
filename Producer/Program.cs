using System.Globalization;
using MassTransit;
using Messaging;
using ProducerService;

var builder = WebApplication.CreateBuilder(args);

var azureServiceBus = builder.Configuration.GetSection("Azure:ServiceBus").Get<AzureServiceBusConfiguration>();
    
builder.Services.ConfigureMassTransit(azureServiceBus.ConnectionString, (context, configurator) =>
{
    EndpointConvention.Map<UpdateSomethingCommand>(new Uri($"queue:{QueueNames.CONSUMER_SERVICE_QUEUE}"));
});

var app = builder.Build();
app.MapGet("/", () => "Producer started!");

var publisher = app.Services.GetRequiredService<IBus>();

// await publisher.Publish(new WelcomeMessage());
await publisher.Publish(new YouAreWelcomedEvent());

await publisher.Send(new UpdateSomethingCommand(){ Value = DateTime.Now.ToString(CultureInfo.InvariantCulture)});

app.Run();
