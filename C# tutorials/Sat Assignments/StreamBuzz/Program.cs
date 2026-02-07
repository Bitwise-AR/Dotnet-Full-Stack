using System;

class Program
{
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
    }

    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        foreach (var creator in records)
        {
            int count = 0;
            foreach (var likes in creator.WeeklyLikes)
            {
                if (likes >= likeThreshold)
                    count++;
            }
            if (count > 0)
                result[creator.CreatorName] = count;
        }
        return result;
    }

    public double CalculateAverageLikes()
    {
        double total = 0;
        int count = 0;
        foreach (var creator in CreatorStats.EngagementBoard)
        {
            foreach (var likes in creator.WeeklyLikes)
            {
                total += likes;
                count++;
            }
        }
        return total / count;
    }

    public static void Main(string[] args)
    {
        Program program = new Program();
        while (true)
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Enter Creator Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                double[] likes = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    likes[i] = double.Parse(Console.ReadLine());
                }
                CreatorStats creator = new CreatorStats { CreatorName = name, WeeklyLikes = likes };
                program.RegisterCreator(creator);
                Console.WriteLine("Creator registered successfully");
                Console.WriteLine();
                Console.WriteLine();
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter like threshold:");
                double threshold = double.Parse(Console.ReadLine());
                var topPosts = program.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);
                if (topPosts.Count == 0)
                {
                    Console.WriteLine("No top-performing posts this week");
                }
                else
                {
                    foreach (var entry in topPosts)
                    {
                        Console.WriteLine($"{entry.Key} - {entry.Value}");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            else if (choice == 3)
            {
                double average = program.CalculateAverageLikes();
                Console.WriteLine($"Overall average weekly likes: {average}");
                Console.WriteLine();
                Console.WriteLine();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                return;
            }
        }
    }
}
