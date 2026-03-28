using System;

class Program
{
    public static event Action<string, double> GoldSaleStarted;
    public static event Action<string, double, double> WeightEvaluated;
    public static event Action<string, double, double, double> PriceCalculated;

    static void Main(string[] args)
    {
        GoldSaleStarted += EvaluateWeight;
        WeightEvaluated += CalculatePrice;
        PriceCalculated += ProcessPayment;

        Console.WriteLine("Select Jewellry Item:");
        Console.WriteLine("1. Gold Chain");
        Console.WriteLine("2. Gold Ring");
        Console.WriteLine("3. Gold Bracelet");
        Console.Write("Enter choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        string product = choice switch
        {
            1 => "Gold Chain",
            2 => "Gold Ring",
            3 => "Gold Bracelet",
            _ => "Gold Item"
        };

        Console.Write("Enter gold rate per gram: Rs ");
        double rate = Convert.ToDouble(Console.ReadLine());

        GoldSaleStarted?.Invoke(product, rate);

        Console.ReadLine();
    }

    static void EvaluateWeight(string product, double rate)
    {
        Console.Write($"Enter weight of {product} in grams: ");
        double weight = Convert.ToDouble(Console.ReadLine());

        WeightEvaluated?.Invoke(product, weight, rate);
    }

    static void CalculatePrice(string product, double weight, double rate)
    {
        double total = weight * rate;
        Console.WriteLine($"Calculated Price: Rs {total}");

        PriceCalculated?.Invoke(product, weight, rate, total);
    }

    static void ProcessPayment(string product, double weight, double rate, double total)
    {
        Console.WriteLine("\n--- Payment Summary ---");
        Console.WriteLine($"Product: {product}");
        Console.WriteLine($"Weight Measured: {weight}g");
        Console.WriteLine($"Rate: Rs {rate}/g");
        Console.WriteLine($"Total Payable: Rs {total}");
    }
}