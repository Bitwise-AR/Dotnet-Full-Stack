using Security.Authentication;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Task 1: AreSameFace ===");
        Console.WriteLine(Authenticator.AreSameFace(new FacialFeatures("green", 0.9m), new FacialFeatures("green", 0.9m)));
        Console.WriteLine(Authenticator.AreSameFace(new FacialFeatures("blue", 0.9m), new FacialFeatures("green", 0.9m)));

        Console.WriteLine("\n=== Task 2: IsAdmin ===");
        var authenticator = new Authenticator();
        Console.WriteLine(authenticator.IsAdmin(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m))));
        Console.WriteLine(authenticator.IsAdmin(new Identity("admin@thecompetition.com", new FacialFeatures("green", 0.9m))));

        Console.WriteLine("\n=== Task 3: Register ===");
        Console.WriteLine(authenticator.Register(new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m))));
        Console.WriteLine(authenticator.IsRegistered(new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m))));
        Console.WriteLine(authenticator.Register(new Identity("tunde@thecompetition.com", new FacialFeatures("blue", 0.9m))));

        Console.WriteLine("\n=== Task 4: IsRegistered (empty) ===");
        var authenticator2 = new Authenticator();
        Console.WriteLine(authenticator2.IsRegistered(new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.8m))));

        Console.WriteLine("\n=== Task 5: AreSameObject ===");
        var identityA = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        var identityB = identityA;
        Console.WriteLine(Authenticator.AreSameObject(identityA, identityB));
        var identityC = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        var identityD = new Identity("alice@thecompetition.com", new FacialFeatures("blue", 0.9m));
        Console.WriteLine(Authenticator.AreSameObject(identityC, identityD));
    }
}