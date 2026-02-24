using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceAssessment;
class Program
{
    public static void Main(string[] args)
    {
        // Create repository
        Repository<Order> orderRepository = new Repository<Order>();

        // Add three orders
        orderRepository.Add(new Order { OrderId = 1, CustomerName = "Alice", Amount = 5000 });
        orderRepository.Add(new Order { OrderId = 2, CustomerName = "Bob", Amount = 2000 });
        orderRepository.Add(new Order { OrderId = 3, CustomerName = "Charlie", Amount = 8000 });

        // Define delegates
        Func<double, double> taxCalculator = amount => amount * 0.18; // 18% tax
        Func<double, double> discountCalculator = amount => amount * 0.10; // 10% discount
        Predicate<Order> validator = order => order.Amount >= 1000; // Minimum 1000

        // Create callback
        OrderCallback callback = message => Console.WriteLine($"Callback: {message}");

        // Create notification handlers
        Action<string> logger = message => Console.WriteLine($"Logger: Event: {message}");
        Action<string> notifier = message => Console.WriteLine($"Notifier: Event: {message}");

        // Combine handlers into multicast delegate
        Action<string> multicastHandler = logger + notifier;

        // Create processor and subscribe to event
        OrderProcessor processor = new OrderProcessor();
        processor.OrderProcessed += multicastHandler;

        // Process each order
        foreach (Order order in orderRepository.GetAll())
        {
            processor.ProcessOrder(order, taxCalculator, discountCalculator, validator, callback);
        }

        // Sort orders by amount in descending order
        List<Order> sortedOrders = orderRepository.GetAll();
        sortedOrders.Sort((order1, order2) => order2.Amount.CompareTo(order1.Amount));

        Console.WriteLine("\nSorted Orders (Descending Amount):");
        foreach (Order order in sortedOrders)
        {
            Console.WriteLine(order.ToString());
        }
    }
}