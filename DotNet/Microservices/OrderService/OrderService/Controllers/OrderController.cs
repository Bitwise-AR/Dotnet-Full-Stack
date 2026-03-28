using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly RabbitMqPublisher _publisher;

        public OrderController(RabbitMqPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpPost]
        public IActionResult CreateOrder()
        {
            var correlationId = HttpContext.Items["X-Correlation-ID"]?.ToString();

            var order = new OrderCreatedEvent
            {
                OrderId = Guid.NewGuid().ToString(),
                Amount = 500
            };

            _publisher.Publish(order, correlationId);

            return Ok(new { Message = "Order placed", CorrelationId = correlationId });
        }
    }
}
