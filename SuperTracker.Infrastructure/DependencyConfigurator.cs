using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SuperTracker.Core.Configurations;

public static class DependencyConfigurator
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetRequiredSection(RabbitMQConfiguration.Position);

        var rabbitMQConfiguration = new RabbitMQConfiguration();

        section.Bind(rabbitMQConfiguration);

        services.AddSingleton(rabbitMQConfiguration);

        services.AddSingleton<IConnectionFactory, ConnectionFactory>(sp =>
              {
                  var factory = new ConnectionFactory()
                  {
                      HostName = rabbitMQConfiguration.HostName,
                      UserName = rabbitMQConfiguration.Username,
                      Password = rabbitMQConfiguration.Password,
                      Port  = rabbitMQConfiguration.Port
                  };
                  return factory;
              });

        return services;
    }
}