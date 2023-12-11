namespace SuperTracker.Core.Configurations;

public class RabbitMQConfiguration
{
    public static string Position => "RabbitMQ";
    public string HostName { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public int Port { get; set; }
    public string QueueName { get; set; } = default!;
}