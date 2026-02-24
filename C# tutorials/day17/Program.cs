using System;

class Program
{
    static void Main(string[] args)
    {
        // ===== STORES =====
        var store1 = new Store(1, "Downtown Store");

        // ===== CATEGORIES =====
        var category1 = new Category(1, "Mountain Bikes");
        var category2 = new Category(2, "Road Bikes");

        // ===== BRANDS =====
        var brand1 = new Brand(1, "Trek");
        var brand2 = new Brand(2, "Giant");

        // ===== PRODUCTS =====
        var product1 = new Product(
            productId: 101,
            productName: "Trek X100",
            brand: brand1,
            category: category1,
            modelYear: 2024,
            listPrice: 45000
        );

        var product2 = new Product(
            productId: 102,
            productName: "Giant Pro",
            brand: brand2,
            category: category2,
            modelYear: 2023,
            listPrice: 52000
        );

        // ===== STOCK =====
        var stock1 = new Stock(store1, product1, 15);
        var stock2 = new Stock(store1, product2, 8);

        // ===== STAFF =====
        var manager = new Staff(
            staffId: 1,
            firstName: "Amit",
            lastName: "Sharma",
            store: store1
        );

        var salesExec = new Staff(
            staffId: 2,
            firstName: "Shruti",
            lastName: "Shahi",
            store: store1,
            manager: manager
        );

        // ===== CUSTOMER =====
        var customer = new Customer(
            customerId: 1,
            firstName: "Ayush",
            lastName: "Raj"
        );

        // ===== ORDER =====
        var order = new Order(
            orderId: 1001,
            customer: customer,
            staff: salesExec,
            store: store1
        );

        // ===== ORDER ITEMS =====
        var item1 = new OrderItem(
            order: order,
            itemId: 1,
            product: product1,
            quantity: 2,
            discount: 0.10m
        );

        var item2 = new OrderItem(
            order: order,
            itemId: 2,
            product: product2,
            quantity: 1,
            discount: 0.05m
        );

        // ===== OUTPUT CHECK =====
        Console.WriteLine("Order Summary");
        Console.WriteLine("----------------------------");
        Console.WriteLine($"Customer: {order.Customer.FirstName} {order.Customer.LastName}");
        Console.WriteLine($"Store: {order.Store.StoreName}");
        Console.WriteLine($"Handled By: {order.Staff.FirstName}");
        Console.WriteLine();

        foreach (var item in order.OrderItems)
        {
            Console.WriteLine(
                $"{item.Product.ProductName} | Qty: {item.Quantity} | Price: {item.ListPrice}"
            );
        }

        Console.WriteLine();
        Console.WriteLine($"Total Orders by Customer: {customer.Orders.Count}");
        Console.WriteLine($"Staff Orders Handled: {salesExec.Orders.Count}");
        Console.WriteLine($"Store Inventory Items: {store1.Stocks.Count}");
    }
}
