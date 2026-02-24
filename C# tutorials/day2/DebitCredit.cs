// Mini Project: Finance Management System (C#)

// ⸻

// 1. Problem Statement (Verified)

// The aim of this project is to develop a menu-driven finance management system using C#, demonstrating the use of classes, functions, loops, conditional statements, and switch-case.
// The project is divided into Debit and Credit operations, each handling distinct financial activities related to money outflow and inflow.

// ⸻

// 2. Project Rules (Validated)
// 	1.	Two classes are used:
// 	•	Debit
// 	•	Credit
// 	2.	Each class contains exactly four different functions.
// 	3.	Menu navigation is implemented using switch-case.
// 	4.	Decision making is implemented using if–else and logical operators.
// 	5.	Loops are used for repetitive calculations.
// 	6.	Program executes until the user selects Exit.

// ⸻

// 3. Class: Debit (Money Outflow Operations)

// The Debit class handles financial activities where money is spent, deducted, or restricted.

// ⸻

// Function 1: ATM Withdrawal Limit Validation

// Purpose:
// To verify whether the withdrawal amount is within the daily ATM limit.

// Rules / Logic:
// 	•	User enters withdrawal amount.
// 	•	Daily withdrawal limit is fixed (₹40,000).
// 	•	If withdrawal amount ≤ limit → allowed.
// 	•	If withdrawal amount > limit → rejected.

// Expected Output:
// 	•	“Withdrawal permitted within daily limit.”
// 	•	OR
// 	•	“Daily ATM withdrawal limit exceeded.”

// ⸻

// Function 2: EMI Burden Evaluation

// Purpose:
// To determine whether a customer can manage a loan EMI.

// Rules / Logic:
// 	•	User enters monthly income.
// 	•	User enters EMI amount.
// 	•	EMI must not exceed 40% of monthly income.
// 	•	EMI ≤ 40% → manageable.
// 	•	EMI > 40% → financial burden.

// Expected Output:
// 	•	“EMI is financially manageable.”
// 	•	OR
// 	•	“EMI exceeds safe income limit.”

// ⸻

// Function 3: Transaction-Based Daily Spending Calculator

// Purpose:
// To calculate total spending from multiple debit transactions.

// Rules / Logic:
// 	•	User enters number of transactions.
// 	•	Loop runs for each transaction.
// 	•	Transaction amounts are summed.

// Loop Used:
// 	•	for or while loop

// Expected Output:
// 	•	“Total debit amount for the day: ₹XXXX”

// ⸻

// Function 4: Minimum Balance Compliance Check

// Purpose:
// To check whether the account maintains the required minimum balance.

// Rules / Logic:
// 	•	Minimum balance required: ₹2,000.
// 	•	User enters current balance.
// 	•	Balance < ₹2,000 → penalty applicable.
// 	•	Balance ≥ ₹2,000 → compliant.

// Expected Output:
// 	•	“Minimum balance not maintained. Penalty applicable.”
// 	•	OR
// 	•	“Minimum balance requirement satisfied.”

// ⸻

// 4. Class: Credit (Money Inflow Operations)

// The Credit class manages financial activities where money is earned, credited, or accumulated.

// ⸻

// Function 1: Net Salary Credit Calculation

// Purpose:
// To calculate the net salary credited after deductions.

// Rules / Logic:
// 	•	User enters gross salary.
// 	•	Fixed deduction of 10% is applied.
// 	•	Net salary is calculated.

// Expected Output:
// 	•	“Net salary credited: ₹XXXX”

// ⸻

// Function 2: Fixed Deposit Maturity Calculation

// Purpose:
// To calculate the maturity amount of a fixed deposit.

// Rules / Logic:
// 	•	User enters principal, rate of interest, and time period.
// 	•	Simple interest is calculated.
// 	•	Maturity amount = Principal + Interest.

// Expected Output:
// 	•	“Fixed Deposit maturity amount: ₹XXXX”

// ⸻

// Function 3: Credit Card Reward Points Evaluation

// Purpose:
// To calculate reward points based on spending.

// Rules / Logic:
// 	•	User enters total credit card spending.
// 	•	1 reward point is earned for every ₹100 spent.
// 	•	Reward points are calculated using division.

// Expected Output:
// 	•	“Reward points earned: XXXX”

// ⸻

// Function 4: Employee Bonus Eligibility Check

// Purpose:
// To determine bonus eligibility based on salary and experience.

// Rules / Logic:
// 	•	Annual salary ≥ ₹5,00,000
// 	•	Years of service ≥ 3
// 	•	Both conditions must be satisfied.

// Conditions Used:
// 	•	Logical AND (&&)

// Expected Output:
// 	•	“Employee is eligible for bonus.”
// 	•	OR
// 	•	“Employee is not eligible for bonus.”

// ⸻

// 5. Menu System (Confirmed Correct)

// Main Menu Options:
// 	1.	Debit Operations
// 	2.	Credit Operations
// 	3.	Exit

// Rules:
// 	•	Menu displayed repeatedly using a loop.
// 	•	Selection handled using switch-case.
// 	•	Exit terminates the program.

// ⸻

class DebitCredit
{
    class Debit
    {
        void AtmWithdrawalLimitValidation()
        {
            Console.Write("Enter withdrawal amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            double limit = 40000;
            if (amount <= limit)
                Console.WriteLine("Withdrawal permitted within daily limit.");
            else
                Console.WriteLine("Daily ATM withdrawal limit exceeded.");
        }

        void EmiBurdenEvaluation()
        {
            Console.Write("Enter monthly income: ");
            double income = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter EMI amount: ");
            double emi = Convert.ToDouble(Console.ReadLine());
            if (emi <= 0.4 * income)
                Console.WriteLine("EMI is financially manageable.");
            else
                Console.WriteLine("EMI exceeds safe income limit.");
        }

        void DailySpendingCalculator()
        {
            Console.Write("Enter number of transactions: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double total = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter amount for transaction {i + 1}: ");
                double amt = Convert.ToDouble(Console.ReadLine());
                total += amt;
            }
            Console.WriteLine($"Total debit amount for the day: ₹{total}");
        }

        void MinimumBalanceComplianceCheck()
        {
            Console.Write("Enter current balance: ");
            double balance = Convert.ToDouble(Console.ReadLine());
            if (balance < 2000)
                Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
            else
                Console.WriteLine("Minimum balance requirement satisfied.");
        }

        public void Menu()
        {
            int choice = 0;
            while (choice != 5)
            {
                Console.WriteLine("\nDebit Operations Menu:");
                Console.WriteLine("1. ATM Withdrawal Limit Validation");
                Console.WriteLine("2. EMI Burden Evaluation");
                Console.WriteLine("3. Daily Spending Calculator");
                Console.WriteLine("4. Minimum Balance Compliance Check");
                Console.WriteLine("5. Exit to Main Menu");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AtmWithdrawalLimitValidation();
                        break;
                    case 2:
                        EmiBurdenEvaluation();
                        break;
                    case 3:
                        DailySpendingCalculator();
                        break;
                    case 4:
                        MinimumBalanceComplianceCheck();
                        break;
                    case 5:
                        Console.WriteLine("Exiting to Main Menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    class Credit
    {
        void NetSalaryCreditCalculation()
        {
            Console.Write("Enter gross salary: ");
            double grossSalary = Convert.ToDouble(Console.ReadLine());
            double netSalary = grossSalary * 0.9;
            Console.WriteLine($"Net salary credited: ₹{netSalary}");
        }

        void FixedDepositMaturityCalculation()
        {
            Console.Write("Enter principal amount: ");
            double principal = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter rate of interest (%): ");
            double rate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter time period (years): ");
            double time = Convert.ToDouble(Console.ReadLine());
            double interest = (principal * rate * time) / 100;
            double maturityAmount = principal + interest;
            Console.WriteLine($"Fixed Deposit maturity amount: ₹{maturityAmount}");
        }
        void CreditCardRewardPointsEvaluation()
        {
            Console.Write("Enter total credit card spending: ");
            double spending = Convert.ToDouble(Console.ReadLine());
            int rewardPoints = (int)(spending / 100);
            Console.WriteLine($"Reward points earned: {rewardPoints}");
        }
        void EmployeeBonusEligibilityCheck()
        {
            Console.Write("Enter annual salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter years of service: ");
            int years = Convert.ToInt32(Console.ReadLine());
            if (salary >= 500000 && years >= 3)
                Console.WriteLine("Employee is eligible for bonus.");
            else
                Console.WriteLine("Employee is not eligible for bonus.");
        }
        public void Menu()
        {
            int choice = 0;
            while (choice != 5)
            {
                Console.WriteLine("\nCredit Operations Menu:");
                Console.WriteLine("1. Net Salary Credit Calculation");
                Console.WriteLine("2. Fixed Deposit Maturity Calculation");
                Console.WriteLine("3. Credit Card Reward Points Evaluation");
                Console.WriteLine("4. Employee Bonus Eligibility Check");
                Console.WriteLine("5. Exit to Main Menu");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        NetSalaryCreditCalculation();
                        break;
                    case 2:
                        FixedDepositMaturityCalculation();
                        break;
                    case 3:
                        CreditCardRewardPointsEvaluation();
                        break;
                    case 4:
                        EmployeeBonusEligibilityCheck();
                        break;
                    case 5:
                        Console.WriteLine("Exiting to Main Menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
    public void MainMenu()
    {
        int choice = 0;
        while (choice != 3)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Debit Operations");
            Console.WriteLine("2. Credit Operations");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    new Debit().Menu();
                    break;
                case 2:
                    new Credit().Menu();
                    break;
                case 3:
                    Console.WriteLine("Exiting the main menu...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}