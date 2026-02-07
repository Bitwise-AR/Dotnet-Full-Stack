class BankAcc
{
    // Encapsulation (private fields)
    private int accountNo;
    private double balance;

    // Static Field
    public static string BankName = "State Bank Of India";

    // Constructor
    public BankAcc(int accNo, double initialBalance)
    {
        accountNo = accNo;
        balance = initialBalance;
    }

    // Method Overloading - Deposit
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine("Amount deposited successfully.");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    // Overloaded Deposit using ref
    public void Deposit(ref double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            amount = 0; // cleared after deposit
            Console.WriteLine("Amount deposited using ref.");
        }
    }

    // Withdraw using out
    public bool Withdraw(double amount, out string message)
    {
        if (amount <= 0)
        {
            message = "Invalid withdrawal amount.";
            return false;
        }

        if (amount > balance)
        {
            message = "Insufficient balance.";
            return false;
        }

        balance -= amount;
        message = "Withdrawal successful.";
        return true;
    }

    // Display Account Details
    public void Display()
    {
        Console.WriteLine("---------------");
        Console.WriteLine($"Bank Name  : {BankName}");
        Console.WriteLine($"Account No : {accountNo}");
        Console.WriteLine($"Balance    : ₹{balance}");
        Console.WriteLine("---------------");
    }

    public static void Menu()
    {
        Console.WriteLine("Welcome to Banking System");

        // TryParse for safe input
        Console.Write("Enter Account Number: ");
        int accNo;
        while (!int.TryParse(Console.ReadLine(), out accNo))
        {
            Console.Write("Invalid input. Enter valid Account Number: ");
        }

        Console.Write("Enter Initial Balance: ");
        double initBalance;
        while (!double.TryParse(Console.ReadLine(), out initBalance))
        {
            Console.Write("Invalid input. Enter valid Balance: ");
        }

        // Create Account
        BankAcc account = new BankAcc(accNo, initBalance);

        int choice;
        do
        {
            Console.WriteLine("\n1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Display Account");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");

            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    Console.Write("Enter deposit amount: ");
                    double depAmount;
                    if (double.TryParse(Console.ReadLine(), out depAmount))
                    {
                        account.Deposit(depAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                    break;

                case 2:
                    Console.Write("Enter withdrawal amount: ");
                    double wAmount;
                    if (double.TryParse(Console.ReadLine(), out wAmount))
                    {
                        if (account.Withdraw(wAmount, out string msg))
                            Console.WriteLine(msg);
                        else
                            Console.WriteLine(msg);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                    break;

                case 3:
                    account.Display();
                    break;

                case 4:
                    Console.WriteLine("Thank you for banking with us!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 4);
    }
}
