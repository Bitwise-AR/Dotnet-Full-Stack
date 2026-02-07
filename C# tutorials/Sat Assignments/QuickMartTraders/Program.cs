﻿class Program
{
    public static SaleTransaction? LastTransaction;
    public static bool HasLastTransaction = false;

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("================== QuickMart Traders ==================\n1. Create New Transaction (Enter Purchase & Selling Details)\n2. View Last Transaction\n3. Calculate Profit/Loss (Recompute & Print)\n4. Exit\nEnter your option:");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                continue;
            }
            switch (choice)
            {
                case 1:
                    LastTransaction = new SaleTransaction();
                    string? input;
                    Console.Write("Enter Invoice No: ");
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Invoice Number cannot be empty.");
                        break;
                    }
                    LastTransaction.InvoiceNo = input;
                    Console.Write("Enter Customer Name: ");
                    input = Console.ReadLine();  // Added: Read input for customer name
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Customer Name cannot be empty.");
                        break;
                    }
                    LastTransaction.CustomerName = input;
                    Console.Write("Enter Item Name: ");
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Item Name cannot be empty.");
                        break;
                    }
                    LastTransaction.ItemName = input;
                    Console.Write("Enter Quantity: ");
                    int quantity;
                    if (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                    {
                        Console.WriteLine("Quantity must be a non-negative integer.");
                        break;
                    }
                    LastTransaction.Quantity = quantity;
                    Console.Write("Enter Purchase Amount (total): ");
                    decimal purchaseAmount;
                    if (!decimal.TryParse(Console.ReadLine(), out purchaseAmount) || purchaseAmount < 0)
                    {
                        Console.WriteLine("Purchase Amount must be a non-negative decimal.");
                        break;
                    }
                    LastTransaction.PurchaseAmount = purchaseAmount;
                    Console.Write("Enter Selling Amount (total): ");
                    decimal sellingAmount;
                    if (!decimal.TryParse(Console.ReadLine(), out sellingAmount) || sellingAmount < 0)
                    {
                        Console.WriteLine("Selling Amount must be a non-negative decimal.");
                        break;
                    }
                    LastTransaction.SellingAmount = sellingAmount;
                    HasLastTransaction = true;
                    Console.WriteLine("Transaction saved successfully.");
                    Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus()}");
                    Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount(LastTransaction.ProfitOrLossStatus()):F2}");
                    Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent(LastTransaction.ProfitOrLossAmount(LastTransaction.ProfitOrLossStatus())):F2}");
                    break;
                case 2:
                    if (!HasLastTransaction)
                    {
                        Console.WriteLine("No bill available. Please create a new bill first.");
                    }
                    else
                    {
                        Console.WriteLine("-------------- Last Transaction --------------");
                        Console.WriteLine($"InvoiceNo: {LastTransaction?.InvoiceNo}");
                        Console.WriteLine($"Customer: {LastTransaction?.CustomerName}");
                        Console.WriteLine($"Item: {LastTransaction?.ItemName}");
                        Console.WriteLine($"Quantity: {LastTransaction?.Quantity}");
                        Console.WriteLine($"Purchase Amount: {LastTransaction?.PurchaseAmount:F2}");
                        Console.WriteLine($"Selling Amount: {LastTransaction?.SellingAmount:F2}");
                        Console.WriteLine($"Status: {LastTransaction?.ProfitOrLossStatus()}");
                        Console.WriteLine($"Profit/Loss Amount: {LastTransaction?.ProfitOrLossAmount(LastTransaction?.ProfitOrLossStatus() ?? ""):F2}");
                        Console.WriteLine($"Profit Margin (%): {LastTransaction?.ProfitMarginPercent(LastTransaction?.ProfitOrLossAmount(LastTransaction?.ProfitOrLossStatus() ?? "") ?? 0):F2}");
                        Console.WriteLine("--------------------------------------------");
                    }

                    break;
                case 3:
                    LastTransaction = null;
                    HasLastTransaction = false;
                    Console.WriteLine("=========Last Transaction Cleared========");
                    break;
                case 4:
                    Console.WriteLine("Thank you. Application closed normally.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

        }
    }
}