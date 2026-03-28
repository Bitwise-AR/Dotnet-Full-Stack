namespace BillingService.Models
{
    public class OrderCreatedEvent
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}
