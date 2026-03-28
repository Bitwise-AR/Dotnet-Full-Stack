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

var results = new Dictionary<string, Dictionary<int, (int? square, int? cube)>>();

Console.Write("Enter numbers (comma separated): ");
var input = Console.ReadLine();

var numbers = input.Split(',')
    .Select(x => x.Trim())
    .Where(x => !string.IsNullOrWhiteSpace(x))
    .Select(x =>
    {
        if (!int.TryParse(x, out int num))
        {
            Console.WriteLine($"Invalid input: {x}");
            throw new Exception("Invalid number format");
        }
        return num;
    })
    .ToList();

var correlationId = Guid.NewGuid().ToString();

results[correlationId] = new Dictionary<int, (int?, int?)>();
foreach (var num in numbers)
{
    results[correlationId][num] = (null, null);
}

var msg = new Message
{
    CorrelationId = correlationId,
    Numbers = numbers
};

var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg));

channel.BasicPublish("", "number_queue", null, body);

Console.WriteLine($"Sent numbers with CorrelationId: {correlationId}");

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var msg = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(body));

    if (!results.ContainsKey(msg.CorrelationId))
        return;

    var numberResults = results[msg.CorrelationId];

    if (!numberResults.ContainsKey(msg.Number))
        numberResults[msg.Number] = (null, null);

    var current = numberResults[msg.Number];

    if (msg.Type == "square")
        current.square = msg.Result;
    else if (msg.Type == "cube")
        current.cube = msg.Result;

    numberResults[msg.Number] = current;

    bool allDone = numberResults.Values.All(x => x.square.HasValue && x.cube.HasValue);

    if (allDone)
    {
        Console.WriteLine("\nFinal Results:");

        int totalSum = 0;

        foreach (var kvp in numberResults)
        {
            var num = kvp.Key;
            var res = kvp.Value;

            int sum = res.square.Value + res.cube.Value;
            totalSum += sum;

            Console.WriteLine($"{num} -> {res.square} + {res.cube} = {sum}");
        }

        Console.WriteLine($"\nTotal Sum: {totalSum}");

        results.Remove(msg.CorrelationId);
    }
};

channel.BasicConsume("result_queue", true, consumer);

Console.WriteLine("Waiting for results...");
Console.ReadLine();