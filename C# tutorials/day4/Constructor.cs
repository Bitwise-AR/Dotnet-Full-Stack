class Parent
{
    public Parent(int x)
    {
        Console.WriteLine("Parent constructor: " + x);
    }
}

class Child : Parent
{
    public Child() : base(10)
    {
        Console.WriteLine("Child constructor");
    }
}

class Product
{
    public string Name;
    public int Price;

    public Product() { }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

class Employee
{
    private double salary;
    public double Salary
    {
        get { return salary; }
        set
        {
            if (value > 0)
                salary = value;
        }
    }
}