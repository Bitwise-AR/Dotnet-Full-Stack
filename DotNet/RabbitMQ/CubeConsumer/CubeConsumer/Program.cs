using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };

await using var connection = await factory.CreateConnectionAsync();
await using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync("cube-queue", false, false, false);

var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    int num = int.Parse(message);

    // simulate async work
    await Task.Delay(50);

    Console.WriteLine($"Cube: {num * num * num}");
};

await channel.BasicConsumeAsync("cube-queue", true, consumer);

Console.WriteLine("Waiting for cube messages...");
await Task.Delay(-1);