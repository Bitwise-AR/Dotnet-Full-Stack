enum TransactionStatus
{
    Pending,
    Approved,
    Rejected
}

enum Category
{
    Stationery,
    Travel,
    Refreshments,
    Courier
}


interface IRepository<T>
{
    void Add(T item);
    IEnumerable<T> GetAll();
}

class InMemoryRepository<T> : IRepository<T>
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }
}

class PettyCashFund
{
    public string Name { get; }
    public decimal Balance { get; private set; }

    private readonly List<Transaction> _ledger = new();

    public PettyCashFund(string name, decimal openingBalance)
    {
        if (openingBalance < 0)
            throw new ArgumentException("Opening balance cannot be negative");

        Name = name;
        Balance = openingBalance;
    }

    public void ApplyTransaction(Transaction transaction)
    {
        if (transaction.Status != TransactionStatus.Approved)
            throw new InvalidOperationException("Only approved transactions affect balance");

        decimal impact = transaction.GetBalanceImpact();

        if (Balance + impact < 0)
            throw new InvalidOperationException("Insufficient balance");

        Balance += impact;
        _ledger.Add(transaction);
    }

    public IEnumerable<Transaction> GetLedger()
    {
        return _ledger;
    }
}

class ApprovalService
{
    public void ApproveExpense(
        ExpenseTransaction transaction,
        string approverName,
        PettyCashFund fund)
    {
        if (transaction.CreatedBy == approverName)
            throw new InvalidOperationException("Requester cannot approve their own expense");

        transaction.Approve();
        fund.ApplyTransaction(transaction);
    }
}

class AuditLogEntry
{
    public DateTime Timestamp { get; } = DateTime.Now;
    public string User { get; }
    public string Action { get; }

    public AuditLogEntry(string user, string action)
    {
        User = user;
        Action = action;
    }
}

