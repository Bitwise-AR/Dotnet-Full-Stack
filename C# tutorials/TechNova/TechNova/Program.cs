using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Product> inventory = new List<Product>();
        
        Laptop laptop = new Laptop(
            id: 1,
            name: "Gaming Laptop",
            price: 85000,
            brand: "Dell",
            model: "G15",
            warranty: 24,
            power: 180,
            mfgDate: new DateTime(2025, 5, 10),
            ram: 16,
            storage: 512
        );

        Rice rice = new Rice(
            id: 2,
            name: "Basmati Rice",
            price: 1200,
            expiry: new DateTime(2026, 12, 31),
            weight: 5,
            organic: true,
            temp: 25,
            grain: "Long Grain"
        );

        Shirt shirt = new Shirt(
            id: 3,
            name: "Formal Shirt",
            price: 1500,
            size: Size.L,
            fabric: "Cotton",
            gender: Gender.Men,
            color: "Blue",
            isFormal: true
        );

        inventory.Add(laptop);
        inventory.Add(rice);
        inventory.Add(shirt);

        Console.WriteLine("=== INVENTORY LIST ===\n");

        foreach (Product product in inventory)
        {
            PrintProductDetails(product);
            Console.WriteLine("--------------------");
        }
    }

    static void PrintProductDetails(Product product)
    {
        Console.WriteLine($"ID: {product.Id}");
        Console.WriteLine($"Name: {product.Name}");
        Console.WriteLine($"Price: {product.Price}");

        // Pattern matching (safe, clean, no casting mess)
        switch (product)
        {
            case Laptop l:
                Console.WriteLine("Category: Electronics - Laptop");
                Console.WriteLine($"Brand: {l.Brand}");
                Console.WriteLine($"RAM: {l.RAM} GB");
                Console.WriteLine($"Storage: {l.Storage} GB");
                break;

            case Rice r:
                Console.WriteLine("Category: Grocery");
                Console.WriteLine($"Expiry: {r.ExpiryDate.ToShortDateString()}");
                Console.WriteLine($"Weight: {r.WeightKg} kg");
                break;

            case Shirt s:
                Console.WriteLine("Category: Clothing");
                Console.WriteLine($"Size: {s.Size}");
                Console.WriteLine($"Color: {s.Color}");
                break;
        }
    }
}
