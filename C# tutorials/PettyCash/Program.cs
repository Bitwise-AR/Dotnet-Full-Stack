class Program
{
    static decimal ReadDecimal(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (decimal.TryParse(Console.ReadLine(), out decimal value) && value > 0)
                return value;

            Console.WriteLine("Invalid amount. Try again.");
        }
    }

    static DateTime ReadDate(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                return date;

            Console.WriteLine("Invalid date. Try again.");
        }
    }


    static void Main()
    {
        PettyCashFund fund = null;
        var pendingExpenses = new List<ExpenseTransaction>();
        var approvalService = new ApprovalService();

        while (true)
        {
            Console.WriteLine("\n--- Petty Cash Manager ---");
            Console.WriteLine("1. Create Fund");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. Approve Expense");
            Console.WriteLine("4. Add Reimbursement");
            Console.WriteLine("5. View Balance");
            Console.WriteLine("0. Exit");

            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Fund name: ");
                        string name = Console.ReadLine();
                        decimal openingBalance = ReadDecimal("Opening balance: ");

                        fund = new PettyCashFund(name, openingBalance);
                        Console.WriteLine("Fund created successfully.");
                        break;

                    case "2":
                        if (fund == null)
                        {
                            Console.WriteLine("Create a fund first.");
                            break;
                        }

                        Console.Write("Requester name: ");
                        string requester = Console.ReadLine();

                        decimal amount = ReadDecimal("Expense amount: ");
                        DateTime date = ReadDate("Date: ");

                        Console.Write("Narration: ");
                        string narration = Console.ReadLine();

                        Console.Write("Voucher number: ");
                        string voucher = Console.ReadLine();

                        Console.Write("Category (0-Stationery, 1-Travel, 2-Refreshments, 3-Courier): ");
                        Category category = (Category)int.Parse(Console.ReadLine());

                        var expense = new ExpenseTransaction(
                            amount, date, narration, requester, category, voucher);

                        pendingExpenses.Add(expense);
                        Console.WriteLine("Expense submitted for approval.");
                        break;

                    case "3":
                        if (!pendingExpenses.Any())
                        {
                            Console.WriteLine("No pending expenses.");
                            break;
                        }

                        Console.WriteLine("Pending Expenses:");
                        for (int i = 0; i < pendingExpenses.Count; i++)
                        {
                            Console.WriteLine($"{i}. {pendingExpenses[i].Narration} - {pendingExpenses[i].Amount}");
                        }

                        Console.Write("Select the request to approve: ");
                        int index = int.Parse(Console.ReadLine());

                        Console.Write("Approver name: ");
                        string approver = Console.ReadLine();

                        approvalService.ApproveExpense(
                            pendingExpenses[index],
                            approver,
                            fund);

                        pendingExpenses.RemoveAt(index);
                        Console.WriteLine("Expense approved.");
                        break;

                    case "4":
                        if (fund == null)
                        {
                            Console.WriteLine("Create a fund first.");
                            break;
                        }

                        Console.Write("Accountant name: ");
                        string accountant = Console.ReadLine();

                        decimal topUp = ReadDecimal("Top-up amount: ");
                        DateTime topUpDate = ReadDate("Date: ");

                        Console.Write("Narration: ");
                        string topUpNarration = Console.ReadLine();

                        Console.Write("Reference no: ");
                        string refNo = Console.ReadLine();

                        var reimbursement = new ReimbursementTransaction(
                            topUp, topUpDate, topUpNarration, accountant, refNo);

                        fund.ApplyTransaction(reimbursement);
                        Console.WriteLine("Reimbursement added.");
                        break;

                    case "5":
                        if (fund == null)
                        {
                            Console.WriteLine("No fund exists.");
                            break;
                        }

                        Console.WriteLine($"Current Balance: {fund.Balance}");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}
