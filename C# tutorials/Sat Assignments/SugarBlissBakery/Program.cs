using System;
using System.Diagnostics;

public class Program
{
    
    public static Chocolate CalculateDiscountedPrice(Chocolate chocolate)
    {
        chocolate.TotalPrice = chocolate.Quantity * chocolate.PricePerUnit;

        double discountPercentage = 0;

        if (chocolate.Flavour == "Dark")
        {
            discountPercentage = 18;
        }
        else if (chocolate.Flavour == "Milk")
        {
            discountPercentage = 12;
        }
        else if (chocolate.Flavour == "White")
        {
            discountPercentage = 6;
        }

        chocolate.DiscountedPrice =
            chocolate.TotalPrice - (chocolate.TotalPrice * discountPercentage / 100);

        return chocolate;
    }

    public static void Main(string[] args)
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.WriteLine("Application execution started");
        Chocolate chocolate = new Chocolate();

        Console.WriteLine("Enter the flavour");
        chocolate.Flavour = Console.ReadLine();

        Console.WriteLine("Enter the quantity");
        chocolate.Quantity = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the price per unit");
        chocolate.PricePerUnit = int.Parse(Console.ReadLine());

        bool isValid = chocolate.ValidateChocolateFlavour();

        if (!isValid)
        {
            Console.WriteLine("Invalid flavour");
        }
        else
        {
            chocolate = CalculateDiscountedPrice(chocolate);

            Console.WriteLine("Flavour : " + chocolate.Flavour);
            Console.WriteLine("Quantity : " + chocolate.Quantity);
            Console.WriteLine("Price Per Unit : " + chocolate.PricePerUnit);
            Console.WriteLine("Total Price : " + chocolate.TotalPrice);
            Console.WriteLine("Discounted Price : " + chocolate.DiscountedPrice);
        }

        Trace.WriteLine("Application execution ended");
    }
}
