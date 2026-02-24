using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

class Shipment
{
    public string ShipmentCode { get; set; }
    public string TransportMode { get; set; }
    public double Weight { get; set; }
    public int StorageDays { get; set; }
}

class ShipmentDetails : Shipment
{
    public bool ValidateShipmentCode()
    {
        if (ShipmentCode.Length != 7)
            return false;
        if (!ShipmentCode.StartsWith("GC#"))
            return false;
        string digitsPart = ShipmentCode.Substring(3);
        foreach (char c in digitsPart)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }

    public double CalculateTotalCost()
    {
        double RatePerKg = 0.00;
        switch (TransportMode)
        {
            case "Sea":
                RatePerKg = 15.00;
                break;
            case "Air":
                RatePerKg = 50.00;
                break;
            case "Land":
                RatePerKg = 25.00;
                break;
            default:
                throw new InvalidOperationException("Invalid transport mode");
        }

        double totalCost = (double)((Weight * RatePerKg) + Math.Sqrt(StorageDays));
        return totalCost;
    }
}
