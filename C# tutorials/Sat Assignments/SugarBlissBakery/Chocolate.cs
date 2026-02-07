using System;

public class Chocolate
{
    public string Flavour { get; set; }
    public int Quantity { get; set; }
    public int PricePerUnit { get; set; }
    public double TotalPrice { get; set; }
    public double DiscountedPrice { get; set; }

    public bool ValidateChocolateFlavour()
    {
        if (Flavour == "Dark" || Flavour == "Milk" || Flavour == "White")
        {
            return true;
        }
        return false;
    }
}
