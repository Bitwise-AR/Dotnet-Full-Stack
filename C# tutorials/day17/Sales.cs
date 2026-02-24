public class Customer
{
    public int CustomerId { get; }

    public string FirstName { get; }
    public string LastName { get; }
    public string Phone { get; }
    public string Email { get; }

    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }

    public List<Order> Orders { get; } = new();

    public Customer(int customerId, string firstName, string lastName)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
    }
}

public class Store
{
    public int StoreId { get; }

    public string StoreName { get; }
    public string Phone { get; }
    public string Email { get; }

    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }

    public List<Staff> Staffs { get; } = new();
    public List<Order> Orders { get; } = new();
    public List<Stock> Stocks { get; } = new();

    public Store(int storeId, string storeName)
    {
        StoreId = storeId;
        StoreName = storeName;
    }
}

public class Order
{
    public int OrderId { get; }

    public Customer Customer { get; }
    public Staff Staff { get; }
    public Store Store { get; }

    public int OrderStatus { get; set; }
    public DateTime OrderDate { get; }
    public DateTime RequiredDate { get; }
    public DateTime? ShippedDate { get; set; }

    public List<OrderItem> OrderItems { get; } = new();

    public Order(int orderId, Customer customer, Staff staff, Store store)
    {
        OrderId = orderId;
        Customer = customer;
        Staff = staff;
        Store = store;

        OrderDate = DateTime.Now;

        customer.Orders.Add(this);
        staff.Orders.Add(this);
        store.Orders.Add(this);
    }
}

public class OrderItem
{
    public Order Order { get; }
    public int ItemId { get; }

    public Product Product { get; }
    public int Quantity { get; }
    public decimal ListPrice { get; }
    public decimal Discount { get; }

    public OrderItem(Order order, int itemId, Product product, int quantity, decimal discount)
    {
        Order = order;
        ItemId = itemId;
        Product = product;
        Quantity = quantity;
        ListPrice = product.ListPrice;
        Discount = discount;

        order.OrderItems.Add(this);
        product.OrderItems.Add(this);
    }
}

public class Staff
{
    public int StaffId { get; }

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }

    public bool Active { get; set; }

    public Store Store { get; }
    public Staff? Manager { get; }

    public List<Staff> Subordinates { get; } = new();
    public List<Order> Orders { get; } = new();

    public Staff(int staffId, string firstName, string lastName, Store store, Staff? manager = null)
    {
        StaffId = staffId;
        FirstName = firstName;
        LastName = lastName;
        Store = store;
        Manager = manager;

        store.Staffs.Add(this);
        manager?.Subordinates.Add(this);
    }
}
