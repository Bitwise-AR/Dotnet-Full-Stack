using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class User
{
    public int Id{get; set;}
    public string Name{get; set;}
}
class Program
{
    static void Main()
    {
        // // Writing data to a file
        // string path = "data.txt";
        // File.WriteAllText(path, "File I/O Example in C#");

        // Console.WriteLine("Data written to file.");

        // // Reading data from a file
        // string content = File.ReadAllText("data.txt");

        // Console.Write("File Content: " + content);
        // Console.WriteLine();

        // // Using StreamWriter and StreamReader
        // using (StreamWriter writer = new StreamWriter("log.txt"))
        // {
        //     writer.WriteLine("Application Started");
        //     writer.WriteLine("Processing Data");
        //     writer.WriteLine("Application Ended");
        // }

        // using (StreamReader reader = new StreamReader("log.txt"))
        // {
        //     string line;
        //     while ((line = reader.ReadLine()) != null)
        //     {
        //         Console.WriteLine(line);
        //     }
        // }

        // // Persisting Object State Using StreamWriter (Text-Based)
        // User user = new User { Id = 1, Name = "Alice" };

        // using (StreamWriter writer = new StreamWriter("user.txt"))
        // {
        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);
        //     user.Id = 2;

        //     user.Name = "Bob";

        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);
        // }

        // Console.WriteLine("User data saved.");

        // // Restoring Object State Using StreamReader
        // User user = new User();

        // using (StreamReader reader = new StreamReader("user.txt"))
        // {
        //     user.Id = int.Parse(reader.ReadLine()); // 1
        //     user.Name = reader.ReadLine();
        // }

        // Console.WriteLine($"User Loaded: {user.Id}, {user.Name}");

        // // Persisting Object State Using BinaryWriter
        // User user = new User { Id = 2, Name = "Bob" };

        // using (BinaryWriter writer = new BinaryWriter(File.Open("user.bin", FileMode.Create)))
        // {
        //     writer.Write(user.Id);
        //     writer.Write(user.Name);
        // }

        // Console.WriteLine("Binary user data saved.");

        // // How the FileStream Class Is Implemented
        // File.WriteAllText("sample.txt", "Hello File Class");

        // string content = File.ReadAllText("sample.txt");
        // Console.WriteLine(content);


        // // How the FileInfo Class Is Implemented 

        // FileInfo file = new FileInfo("sample.txt");

        // if (!file.Exists)
        // {
        //     using (StreamWriter writer = file.CreateText())
        //     {
        //         writer.WriteLine("Hello FileInfo Class");
        //     }
        // }

        // Console.WriteLine("File Name: " + file.Name);
        // Console.WriteLine("File Size: " + file.Length + " bytes");
        // Console.WriteLine("Created On: " + file.CreationTime);

        // // How the Directory Class Is Implemented 
        // Directory.CreateDirectory("Logs");
        // if (Directory.Exists("Logs"))
        // {
        //     Console.WriteLine("Logs directory created successfully.");
        // }

        // // How the DirectoryInfo Class Is Implemented
        // DirectoryInfo dir = new DirectoryInfo("Logs");

        // if (!dir.Exists)
        // {
        //     dir.Create();
        // }

        // Console.WriteLine("Directory Name: " + dir.Name);
        // Console.WriteLine("Created On: " + dir.CreationTime);
        // Console.WriteLine("Full Path: " + dir.FullName);

        // Serialization Example (Object → JSON → File)
        // User user = new User { Id = 1, Name = "Alice" };
        // string json = JsonSerializer.Serialize(user);
        // File.AppendAllText("user.json", json);
        // Console.WriteLine("User serialized successfully.");

        // Deserialization Example (File → JSON → Object)
        // string json = File.ReadAllText("user.json");
        // User user = JsonSerializer.Deserialize<User>(json);
        // Console.WriteLine($"User Loaded: {user.Id}, {user.Name}");

        // XML serialization
        User user = new User { Id = 1, Name = "Alice" };
        XmlSerializer serializer = new XmlSerializer(typeof(User));
        using (FileStream fs = new FileStream("user.xml", FileMode.Create))
        {
            serializer.Serialize(fs, user);
        }

        Console.WriteLine("XML Serialized");
    }
}
