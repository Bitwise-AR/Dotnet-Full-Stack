using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace ProducerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumberController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Send(int number)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync("square-queue", false, false, false);
            await channel.QueueDeclareAsync("cube-queue", false, false, false);

            var body = Encoding.UTF8.GetBytes(number.ToString());

            await channel.BasicPublishAsync("", "square-queue", body);
            await channel.BasicPublishAsync("", "cube-queue", body);

            return Ok($"Sent {number}");
        }
    }
}
