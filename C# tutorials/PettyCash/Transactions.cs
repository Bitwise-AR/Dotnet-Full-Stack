abstract class Transaction
{
    public Guid Id { get; } = Guid.NewGuid();
    public decimal Amount { get; protected set; }
    public DateTime Date { get; protected set; }
    public string Narration { get; protected set; }
    public TransactionStatus Status { get; protected set; }
    public string CreatedBy { get; protected set; }

    protected Transaction(decimal amount, DateTime date, string narration, string createdBy)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");

        Amount = amount;
        Date = date;
        Narration = narration;
        CreatedBy = createdBy;
        Status = TransactionStatus.Pending;
    }

    public abstract decimal GetBalanceImpact();

    public void Approve()
    {
        if (Status != TransactionStatus.Pending)
            throw new InvalidOperationException("Transaction already processed");

        Status = TransactionStatus.Approved;
    }

    public void Reject()
    {
        if (Status != TransactionStatus.Pending)
            throw new InvalidOperationException("Transaction already processed");

        Status = TransactionStatus.Rejected;
    }
}

class ExpenseTransaction : Transaction
{
    public Category Category { get; }
    public string VoucherNumber { get; }

    public ExpenseTransaction(
        decimal amount,
        DateTime date,
        string narration,
        string createdBy,
        Category category,
        string voucherNumber)
        : base(amount, date, narration, createdBy)
    {
        if (string.IsNullOrWhiteSpace(voucherNumber))
            throw new ArgumentException("Voucher number required");

        Category = category;
        VoucherNumber = voucherNumber;
    }

    public override decimal GetBalanceImpact()
    {
        return -Amount;
    }
}

class ReimbursementTransaction : Transaction
{
    public string ReferenceNumber { get; }

    public ReimbursementTransaction(
        decimal amount,
        DateTime date,
        string narration,
        string createdBy,
        string referenceNumber)
        : base(amount, date, narration, createdBy)
    {
        ReferenceNumber = referenceNumber;
        Status = TransactionStatus.Approved;
    }

    public override decimal GetBalanceImpact()
    {
        return Amount;
    }
}

