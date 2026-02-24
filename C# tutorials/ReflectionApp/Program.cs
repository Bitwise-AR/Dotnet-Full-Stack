using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        // Load DLL dynamically
        Assembly assembly = Assembly.LoadFrom(@"bin\Debug\net10.0\MyLibrary.dll");
        Console.WriteLine("ASSEMBLY LOADED\n");
        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
        {
            Console.WriteLine($"Type: {type.Name}");
            if (type.IsInterface)
            {
                Console.WriteLine("This is an Interface");
            }
            Type[] interfaces = type.GetInterfaces();
            foreach (Type iface in interfaces)
            {
                Console.WriteLine($"Implements Interface: {iface.Name}");
            }
            MemberInfo[] members = type.GetMembers();
            foreach (MemberInfo member in members)
            {
                Console.WriteLine($"Member: {member.MemberType} - {member.Name}");
            }
            Console.WriteLine();
        }
    }
}
