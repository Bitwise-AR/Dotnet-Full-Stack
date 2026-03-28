using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using System.Text;
using Shared;

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("cube_queue", false, false, false);
channel.QueueDeclare("result_queue", false, false, false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var msg = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(body));

    int cube = msg.Number * msg.Number * msg.Number;

    var resultMsg = new Message
    {
        CorrelationId = msg.CorrelationId,
        Number = msg.Number,   // 🔥 FIX
        Result = cube,
        Type = "cube"
    };

    var resultBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(resultMsg));
    channel.BasicPublish("", "result_queue", null, resultBody);

    Console.WriteLine($"[Cube] {msg.Number} → {cube}");
};

channel.BasicConsume("cube_queue", true, consumer);

Console.ReadLine();