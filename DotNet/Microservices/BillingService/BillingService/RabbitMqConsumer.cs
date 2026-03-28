using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using BillingService.Models;

namespace BillingService
{
    public class RabbitMqConsumer : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("order_queue", false, false, false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = JsonSerializer.Deserialize<OrderCreatedEvent>(Encoding.UTF8.GetString(body));

                var correlationId = ea.BasicProperties.CorrelationId;

                Console.WriteLine($"[Billing] Processing Order: {message.OrderId}");
                Console.WriteLine($"[Billing] CorrelationId: {correlationId}");
            };

            channel.BasicConsume(queue: "order_queue", autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
