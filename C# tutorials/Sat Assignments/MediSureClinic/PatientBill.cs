class PatientBill
{
    public string? BillId;
    public string? PatientName;
    public bool HasInsurance;
    public decimal ConsultationFee;
    public decimal LabCharges;
    public decimal MedicineCharges;

    public decimal GrossAmount()
    {
        return ConsultationFee + LabCharges + MedicineCharges;
    }

    public decimal DiscountAmount()
    {
        if (HasInsurance)
        {
            return GrossAmount() * 0.10m;
        }
        return 0;
    }

    public decimal FinalPayable()
    {
        return GrossAmount() - DiscountAmount();
    }
}