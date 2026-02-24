using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        ShipmentDetails shipment = new ShipmentDetails();
        Console.Write("Enter Shipment Code: ");
        shipment.ShipmentCode = Console.ReadLine();
        if (!shipment.ValidateShipmentCode())
        {
            Console.WriteLine("Invalid shipment code");
            return;
        }

        Console.Write("Enter Transport Mode (Sea/Air/Land): ");
        shipment.TransportMode = Console.ReadLine();

        Console.Write("Enter Weight (in kg): ");
        shipment.Weight = double.Parse(Console.ReadLine());

        Console.Write("Enter Storage Days: ");
        shipment.StorageDays = int.Parse(Console.ReadLine());

        Console.WriteLine("The total shippping cost is: " + Math.Round(shipment.CalculateTotalCost(), 2));
    }
}