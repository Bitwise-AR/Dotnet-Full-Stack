using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

public enum Size
{
    S, M, L, XL
}

public enum Gender
{
    Men, Women, Unisex
}


public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    protected Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

public abstract class ElectronicsProduct : Product
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int WarrantyPeriodMonths { get; set; }
    public int PowerUsageWatts { get; set; }
    public DateTime ManufacturingDate { get; set; }

    protected ElectronicsProduct(int id, string name, decimal price,
        string brand, string model, int warranty, int power, DateTime mfgDate)
        : base(id, name, price)
    {
        Brand = brand;
        Model = model;
        WarrantyPeriodMonths = warranty;
        PowerUsageWatts = power;
        ManufacturingDate = mfgDate;
    }
}

public abstract class GroceryProduct : Product
{
    public DateTime ExpiryDate { get; set; }
    public double WeightKg { get; set; }
    public bool IsOrganic { get; set; }
    public double StorageTemperature { get; set; }

    protected GroceryProduct(int id, string name, decimal price,
        DateTime expiry, double weight, bool organic, double temp)
        : base(id, name, price)
    {
        ExpiryDate = expiry;
        WeightKg = weight;
        IsOrganic = organic;
        StorageTemperature = temp;
    }
}
public abstract class ClothingProduct : Product
{
    public Size Size { get; set; }
    public string FabricType { get; set; }
    public Gender Gender { get; set; }
    public string Color { get; set; }

    protected ClothingProduct(int id, string name, decimal price,
        Size size, string fabric, Gender gender, string color)
        : base(id, name, price)
    {
        Size = size;
        FabricType = fabric;
        Gender = gender;
        Color = color;
    }
}

public class Laptop : ElectronicsProduct
{
    public int RAM { get; set; }
    public int Storage { get; set; }
    public Laptop(int id, string name, decimal price,
        string brand, string model, int warranty, int power, DateTime mfgDate,
        int ram, int storage)
        : base(id, name, price, brand, model, warranty, power, mfgDate)
    {
        RAM = ram;
        Storage = storage;
    }
}

public class Rice : GroceryProduct
{
    public string GrainType { get; set; }
    public Rice(int id, string name, decimal price,
        DateTime expiry, double weight, bool organic, double temp, string grain)
        : base(id, name, price, expiry, weight, organic, temp)
    {
        GrainType = grain;
    }
}

public class Shirt : ClothingProduct
{
    public bool IsFormal { get; set; }
    public Shirt(int id, string name, decimal price,
        Size size, string fabric, Gender gender, string color, bool isFormal)
        : base(id, name, price, size, fabric, gender, color)
    {
        IsFormal = isFormal;
    }
}