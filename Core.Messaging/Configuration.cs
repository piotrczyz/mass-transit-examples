using System.Reflection;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging;

public static class Configuration
{
    public static void ConfigureMassTransit(this IServiceCollection services,  Action<IBusRegistrationContext, IBusFactoryConfigurator>? configure = null)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumers(Assembly.GetEntryAssembly());
            x.SetKebabCaseEndpointNameFormatter();
            
            // x.UsingRabbitMq((context, cfg) =>
            // {
            //     cfg.Host("amqps://ottdsnro:8kfD7D5lWl0TVImWY_Rd50qbVHPiQsiW@kangaroo.rmq.cloudamqp.com/ottdsnro", h =>
            //     {
            //         h.UseSsl(s =>
            //         {
            //             s.Protocol = SslProtocols.Tls12;
            //         });
            //     });
            //     
            //     configure?.Invoke(context, cfg);
            // });
            
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host("Endpoint=sb://bcc-platform-dev.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=emtA7tDam8ze+ZuqRjbC4/821rppk6Ci3JmpFVC/TIU=");
                
                
                configure?.Invoke(context, cfg);
            });

            services.AddMassTransitHostedService();
        });
    }
}