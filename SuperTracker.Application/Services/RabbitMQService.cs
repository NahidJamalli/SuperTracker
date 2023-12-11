using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SuperTracker.Core.Interfaces;

public class RabbitMQService(IConnectionFactory connectionFactory) : IRabbitMQService
{
    public void Publish<T>(T message, string queueName)
    {
        using (var connection = connectionFactory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string messageBody = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(messageBody);

            channel.BasicPublish(exchange: "",
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
