// Sealed Security class
sealed class SecurityModule
{
    public void Authenticate()
    {
        Console.WriteLine("User authenticated successfully...");
    }
}

// Abstract base class
abstract class InsurancePolicy
{
    public int PolicyNumber { get; init; }
    public string PolicyHolderName { get; set; }
    
    private double premium;
    public double Premium 
    { 
        get => premium;
        set => premium = value;
    }

    public virtual double CalculatePremium() => Premium;
    
    public void ShowPolicy()
    {
        Console.WriteLine("Insurance Policy");
    }
}

// Life Insurance class
class LifeInsurance : InsurancePolicy
{
    public override double CalculatePremium() => Premium + 500;
    
    public new void ShowPolicy()
    {
        Console.WriteLine("Life Insurance Policy");
    }
}

// Health Insurance class
class HealthInsurance : InsurancePolicy
{
    public sealed override double CalculatePremium() => Premium + 3000;
}

// Policy Directory with indexers
class PolicyDirectory
{
    private List<InsurancePolicy> policies = new List<InsurancePolicy>();
    
    public void AddPolicy(InsurancePolicy policy)
    {
        policies.Add(policy);
    }
    
    public InsurancePolicy this[int index] => policies[index];
    
    public InsurancePolicy this[string name] => policies.Find(p => p.PolicyHolderName == name);
}

class Program
{
    static void Main()
    {
        var security = new SecurityModule();
        security.Authenticate();
        
        var directory = new PolicyDirectory();
        
        var lifePolicy = new LifeInsurance { PolicyNumber = 101, PolicyHolderName = "Amit", Premium = 5000 };
        var healthPolicy = new HealthInsurance { PolicyNumber = 102, PolicyHolderName = "Neha", Premium = 9000 };
        
        directory.AddPolicy(lifePolicy);
        directory.AddPolicy(healthPolicy);
        
        Console.WriteLine(directory[0].PolicyHolderName);
        Console.WriteLine(directory["Neha"].PolicyNumber);
        
        Console.WriteLine($"Life Premium: {lifePolicy.CalculatePremium()}");
        Console.WriteLine($"Health Premium: {healthPolicy.CalculatePremium()}");
        
        lifePolicy.ShowPolicy();
        ((InsurancePolicy)lifePolicy).ShowPolicy();
    }
}
