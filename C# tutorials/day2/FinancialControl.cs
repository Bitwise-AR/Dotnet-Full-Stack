// Design a Finance Control System that performs the following tasks:

// Loan Eligibility Check
// Income Tax Calculation
// Transaction Entry System
// Exit Program

// The system should run continuously until the user chooses to exit.
// Finance Rules Used
// Loan Eligibility Rules
// Age must be 21 years or above
// Monthly income must be ₹30,000 or more


// Income Tax Rules
// Annual Income                Tax Rate
// ≤ ₹2,50,000                  0%
// ₹2,50,001 – ₹5,00,000        5%
// ₹5,00,001 – ₹10,00,000       20%
// Above ₹10,00,000             30%


// Transaction Rules
// User can enter 5 transactions
// Negative amount is invalid
// Invalid transactions should be skipped

// Menu Design (Using switch-case)
// 1. Check Loan Eligibility
// 2. Calculate Tax
// 3. Enter Transactions
// 4. Exit

// Program Flow
// Program starts
// Menu is displayed
// User selects an option
// Selected operation executes
// Menu repeats until user exits

class FinancialControl
{
    public void MainMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Financial Control System Menu:");
            Console.WriteLine("1. Check Loan Eligibility");
            Console.WriteLine("2. Calculate Tax");
            Console.WriteLine("3. Enter Transactions");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CheckLoanEligibility();
                    break;
                case "2":
                    CalculateTax();
                    break;
                case "3":
                    EnterTransactions();
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Exiting the program....!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void CheckLoanEligibility()
    {
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter your monthly income (₹): ");
        decimal income = decimal.Parse(Console.ReadLine());

        if (age >= 21 && income >= 30000)
        {
            Console.WriteLine("You are eligible for a loan.");
        }
        else
        {
            Console.WriteLine("You are not eligible for a loan.");
        }
    }

    static void CalculateTax()
    {
        Console.Write("Enter your annual income (₹): ");
        decimal annualIncome = decimal.Parse(Console.ReadLine());
        decimal tax = 0;

        if (annualIncome <= 250000)
        {
            tax = 0;
        }
        else if (annualIncome <= 500000)
        {
            tax = (annualIncome - 250000) * 0.05m;
        }
        else if (annualIncome <= 1000000)
        {
            tax = (250000 * 0.05m) + ((annualIncome - 500000) * 0.20m);
        }
        else
        {
            tax = (250000 * 0.05m) + (500000 * 0.20m) + ((annualIncome - 1000000) * 0.30m);
        }

        Console.WriteLine($"Your calculated tax is: ₹{tax}");
    }

    static void EnterTransactions()
    {
        int transactionCount = 0;
        decimal totalAmount = 0;

        while (transactionCount < 5)
        {
            Console.Write($"Enter transaction amount #{transactionCount + 1} (or type 'exit' to stop): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            decimal amount;
            if (decimal.TryParse(input, out amount) && amount >= 0)
            {
                totalAmount += amount;
                transactionCount++;
            }
            else
            {
                Console.WriteLine("Invalid transaction amount. Please enter a non-negative number.");
            }
        }

        Console.WriteLine($"Total valid transaction amount entered: ₹{totalAmount}");
    }
}