namespace EcommerceAssessment
{
    // TASK 1: Generic Repository
    public class Repository<T>
    {
        private List<T> items;

        public Repository()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public List<T> GetAll()
        {
            return items;
        }
    }

    // TASK 2: Order Domain Model
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, Customer: {CustomerName}, Amount: {Amount}";
        }
    }

    // TASK 3: Custom Callback Delegate
    public delegate void OrderCallback(string message);

    // TASK 4: Order Processor
    public class OrderProcessor
    {
        public event Action<string> OrderProcessed;

        public void ProcessOrder(Order order, Func<double, double> taxCalculator,
                               Func<double, double> discountCalculator,
                               Predicate<Order> validator, OrderCallback callback)
        {
            if (!validator(order))
            {
                callback("Order validation failed.");
                return;
            }

            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);
            order.Amount = order.Amount + tax - discount;

            callback($"Order {order.OrderId} processed successfully.");
            OrderProcessed?.Invoke($"Order {order.OrderId} completed.");
        }
    }
}