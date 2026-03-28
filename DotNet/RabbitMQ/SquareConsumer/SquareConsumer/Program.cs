using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };

await using var connection = await factory.CreateConnectionAsync();
await using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync("square-queue", false, false, false);

var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    int num = int.Parse(message);

    // simulate async work
    await Task.Delay(50);

    Console.WriteLine($"Square: {num * num}");
};

await channel.BasicConsumeAsync("square-queue", true, consumer);

Console.WriteLine("Waiting for square messages...");
await Task.Delay(-1);