using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SuperTracker.Core.Interfaces;

public static class DependencyConfigurator
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddRabbitMQ();
        services.AddApplicationServices();
        
        return services;
    }

    private static IServiceCollection AddRabbitMQ(this IServiceCollection services)
    {
        services.AddSingleton<IConnectionFactory, ConnectionFactory>(sp =>
              {
                  var factory = new ConnectionFactory()
                  {
                      HostName = "localhost",
                      UserName = "guest",
                      Password = "guest",
                  };
                  return factory;
              });

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IRabbitMQService, RabbitMQService>();

        return services;
    }
}
