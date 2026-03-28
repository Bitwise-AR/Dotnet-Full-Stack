using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using System.Text;
using Shared;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("number_queue", false, false, false);
channel.QueueDeclare("square_queue", false, false, false);
channel.QueueDeclare("cube_queue", false, false, false);
channel.QueueDeclare("result_queue", false, false, false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var msg = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(body));

    foreach (var num in msg.Numbers)
    {
        // Send to cube queue
        var cubeMsg = new Message
        {
            CorrelationId = msg.CorrelationId,
            Number = num
        };

        var cubeBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(cubeMsg));
        channel.BasicPublish("", "cube_queue", null, cubeBody);

        // Process square
        int square = num * num;

        var resultMsg = new Message
        {
            CorrelationId = msg.CorrelationId,
            Number = num,        // 🔥 FIX
            Result = square,
            Type = "square"
        };

        var resultBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(resultMsg));
        channel.BasicPublish("", "result_queue", null, resultBody);

        Console.WriteLine($"[Square] {num} → {square}");
    }
};

channel.BasicConsume("number_queue", true, consumer);

Console.ReadLine();