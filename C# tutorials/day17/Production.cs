public class Category
{
    public int CategoryId { get; }
    public string CategoryName { get; }

    public List<Product> Products { get; } = new();

    public Category(int categoryId, string categoryName)
    {
        CategoryId = categoryId;
        CategoryName = categoryName;
    }
}

public class Product
{
    public int ProductId { get; }

    public string ProductName { get; }
    public Brand Brand { get; }
    public Category Category { get; }

    public short ModelYear { get; }
    public decimal ListPrice { get; }

    public List<OrderItem> OrderItems { get; } = new();
    public List<Stock> Stocks { get; } = new();

    public Product(int productId, string productName, Brand brand, Category category, short modelYear, decimal listPrice)
    {
        ProductId = productId;
        ProductName = productName;
        Brand = brand;
        Category = category;
        ModelYear = modelYear;
        ListPrice = listPrice;

        brand.Products.Add(this);
        category.Products.Add(this);
    }
}

public class Brand
{
    public int BrandId { get; }
    public string BrandName { get; }

    public List<Product> Products { get; } = new();

    public Brand(int brandId, string brandName)
    {
        BrandId = brandId;
        BrandName = brandName;
    }
}

public class Stock
{
    public Store Store { get; }
    public Product Product { get; }
    public int Quantity { get; set; }

    public Stock(Store store, Product product, int quantity)
    {
        Store = store;
        Product = product;
        Quantity = quantity;

        store.Stocks.Add(this);
        product.Stocks.Add(this);
    }
}
