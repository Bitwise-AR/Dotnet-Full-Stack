using System;
using System.Collections;

class Program
{
    public static void Main()
    {
        // TASK 1
        Console.Write("Enter number of products: ");
        int productCount = int.Parse(Console.ReadLine());
        int[] prices = new int[productCount];
        
        for (int i = 0; i < productCount; i++)
        {
            do
            {
                Console.Write($"Enter price for product {i + 1}: ");
                prices[i] = int.Parse(Console.ReadLine());
            } while (prices[i] <= 0);
        }
        
        int sum = 0;
        for (int i = 0; i < prices.Length; i++)
            sum += prices[i];
        double average = (double)sum / prices.Length;
        
        Console.WriteLine("\nTASK 1 - Dynamic Product Price Analysis:");
        Console.WriteLine($"\nAverage Price: {average:F2}");
        
        Array.Sort(prices);
        
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < average)
                prices[i] = 0;
        }
        
        Array.Resize(ref prices, prices.Length + 5);
        for (int i = prices.Length - 5; i < prices.Length; i++)
            prices[i] = (int)average;
        
        Console.WriteLine("\nFinal Product Prices:");
        for (int i = 0; i < prices.Length; i++)
            Console.WriteLine($"Index {i}: {prices[i]}");
        
        // TASK 2
        Console.Write("\nEnter number of branches: ");
        int branches = int.Parse(Console.ReadLine());
        Console.Write("Enter number of months: ");
        int months = int.Parse(Console.ReadLine());
        
        int[,] sales = new int[branches, months];
        
        for (int i = 0; i < branches; i++)
        {
            for (int j = 0; j < months; j++)
            {
                Console.Write($"Enter sales for Branch {i + 1}, Month {j + 1}: ");
                sales[i, j] = int.Parse(Console.ReadLine());
            }
        }
        
        int[] branchTotals = new int[branches];
        int highestSale = sales[0, 0];
        
        for (int i = 0; i < branches; i++)
        {
            for (int j = 0; j < months; j++)
            {
                branchTotals[i] += sales[i, j];
                if (sales[i, j] > highestSale)
                    highestSale = sales[i, j];
            }
        }
        
        Console.WriteLine("\nTASK 2 - Branch Sales Analysis:");
        for (int i = 0; i < branches; i++)
            Console.WriteLine($"Branch {i + 1} Total: {branchTotals[i]}");
        Console.WriteLine($"Highest Monthly Sale: {highestSale}");
        
        // TASK 3
        int[][] jaggedSales = new int[branches][];
        
        for (int i = 0; i < branches; i++)
        {
            int count = 0;
            for (int j = 0; j < months; j++)
            {
                if (sales[i, j] >= average)
                    count++;
            }
            
            jaggedSales[i] = new int[count];
            int index = 0;
            for (int j = 0; j < months; j++)
            {
                if (sales[i, j] >= average)
                    jaggedSales[i][index++] = sales[i, j];
            }
        }
        
        Console.WriteLine("\nTASK 3 - Performance-Based Data:");
        for (int i = 0; i < jaggedSales.Length; i++)
        {
            Console.Write($"Branch {i + 1}: ");
            for (int j = 0; j < jaggedSales[i].Length; j++)
                Console.Write(jaggedSales[i][j] + " ");
            Console.WriteLine();
        }
        
        // TASK 4
        Console.Write("\nEnter number of customer transactions: ");
        int transCount = int.Parse(Console.ReadLine());
        
        List<int> customerIds = new List<int>();
        for (int i = 0; i < transCount; i++)
        {
            Console.Write($"Enter customer ID {i + 1}: ");
            customerIds.Add(int.Parse(Console.ReadLine()));
        }
        
        int originalCount = customerIds.Count;
        HashSet<int> uniqueIds = new HashSet<int>(customerIds);
        customerIds = new List<int>(uniqueIds);
        
        Console.WriteLine("\nTASK 4 - Cleaned Customer List:");
        foreach (int id in customerIds)
            Console.Write(id + " ");
        Console.WriteLine($"\nDuplicates Removed: {originalCount - customerIds.Count}");
        
        // TASK 5
        Console.Write("\nEnter number of financial transactions: ");
        int finCount = int.Parse(Console.ReadLine());
        
        Dictionary<int, double> transactions = new Dictionary<int, double>();
        for (int i = 0; i < finCount; i++)
        {
            Console.Write($"Enter transaction ID {i + 1}: ");
            int id = int.Parse(Console.ReadLine());
            
            if (transactions.ContainsKey(id))
            {
                Console.WriteLine("Duplicate ID. Enter unique ID.");
                i--;
                continue;
            }
            
            Console.Write($"Enter amount for transaction {id}: ");
            double amount = double.Parse(Console.ReadLine());
            transactions.Add(id, amount);
        }
        
        SortedList<int, double> highValueTrans = new SortedList<int, double>();
        foreach (KeyValuePair<int, double> kvp in transactions)
        {
            if (kvp.Value >= average)
                highValueTrans.Add(kvp.Key, kvp.Value);
        }
        
        Console.WriteLine("\nTASK 5 - High-Value Transactions (Sorted):");
        foreach (KeyValuePair<int, double> kvp in highValueTrans)
            Console.WriteLine($"ID: {kvp.Key}, Amount: {kvp.Value:F2}");
        
        // TASK 6
        Console.Write("\nEnter number of operations: ");
        int opCount = int.Parse(Console.ReadLine());
        
        Queue<string> processQueue = new Queue<string>();
        Stack<string> undoStack = new Stack<string>();
        
        for (int i = 0; i < opCount; i++)
        {
            Console.Write($"Enter operation {i + 1}: ");
            string op = Console.ReadLine();
            processQueue.Enqueue(op);
            undoStack.Push(op);
        }
        
        Console.WriteLine("\nTASK 6 - Processed Operations (FIFO):");
        while (processQueue.Count > 0)
            Console.WriteLine(processQueue.Dequeue());
        
        Console.WriteLine("\nUndone Operations (Last 2):");
        for (int i = 0; i < 2 && undoStack.Count > 0; i++)
            Console.WriteLine(undoStack.Pop());
        
        // TASK 7
        Console.Write("\nEnter number of users: ");
        int userCount = int.Parse(Console.ReadLine());
        
        Hashtable userRoles = new Hashtable();
        ArrayList legacyData = new ArrayList();
        
        for (int i = 0; i < userCount; i++)
        {
            Console.Write($"Enter username {i + 1}: ");
            string username = Console.ReadLine();
            Console.Write($"Enter role for {username}: ");
            string role = Console.ReadLine();
            
            userRoles.Add(username, role);
            legacyData.Add(username);
            legacyData.Add(role);
        }
        
        Console.WriteLine("\nTASK 7 - Hashtable: ");
        foreach (DictionaryEntry entry in userRoles)
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        
        Console.WriteLine("\nArrayList: ");
        foreach (object item in legacyData)
            Console.Write(item + " ");
        Console.WriteLine("\n\nRisk: ArrayList allows mixed types, no compile-time type safety, requires casting, prone to runtime errors.");
    }
}
