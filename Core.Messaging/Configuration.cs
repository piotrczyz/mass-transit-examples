using System.Reflection;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging;

public static class Configuration
{
    public static void ConfigureMassTransit(this IServiceCollection services, string busConnectionString,  Action<IBusRegistrationContext, IBusFactoryConfigurator>? configure = null)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumers(Assembly.GetEntryAssembly());
            x.SetKebabCaseEndpointNameFormatter();
            
            // x.UsingRabbitMq((context, cfg) =>
            // {
            //     cfg.Host(busConnectionString, h =>
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
                cfg.Host(busConnectionString);
                configure?.Invoke(context, cfg);
            });

            services.AddMassTransitHostedService();
        });
    }
}