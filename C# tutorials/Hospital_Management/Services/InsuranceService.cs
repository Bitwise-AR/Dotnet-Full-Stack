public class InsuranceService
{
    public double ApplyCoverage(double billAmount, int coveragePercent)
    {
        double discount = billAmount * coveragePercent / 100;
        return billAmount - discount;
    }
}