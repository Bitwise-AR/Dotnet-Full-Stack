class SaleTransaction
{
    public string? InvoiceNo;
    public string? CustomerName;
    public string? ItemName;
    public int Quantity;
    public decimal PurchaseAmount;
    public decimal SellingAmount;   
    public string ProfitOrLossStatus()
    {
        if(SellingAmount > PurchaseAmount)
            return "PROFIT";
        else if(SellingAmount < PurchaseAmount)
            return "LOSS";
        else
            return "BREAK-EVEN";
    }
    public decimal ProfitOrLossAmount(string ProfitOrLossStatus)
    {
        if(ProfitOrLossStatus == "PROFIT")
        {
            return SellingAmount - PurchaseAmount;
        }
        else if(ProfitOrLossStatus == "LOSS")
        {
            return PurchaseAmount - SellingAmount;
        }
        else
        {
            return 0;
        }
    }
    public decimal ProfitMarginPercent(decimal ProfitOrLossAmount)
    {
        return ProfitOrLossAmount / PurchaseAmount  * 100;
    }

}