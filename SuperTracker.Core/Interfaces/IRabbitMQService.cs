namespace SuperTracker.Core.Interfaces;

public interface IRabbitMQService
{
    void Publish<T>(T message, string queueName);
}