class BankAccount
{
    public int accNum;
    private double balance;


    public void setBalance(double balance)
    {
        this.balance = balance;
    }
    
    public void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine("Updated Balance: " + balance);
    }
    
}

class Employee {
    public string Name;
    public int Salary;

    public void DisplayDetails()
    {
        Console.WriteLine(Name + " earns " + Salary);
    }
}

class Wallet
{
    private double money;

    public void addMoney(double amount)
    {
        money += amount;
    }

    public void getBalance()
    {
        Console.WriteLine("Balance: " + money);
    }
}
