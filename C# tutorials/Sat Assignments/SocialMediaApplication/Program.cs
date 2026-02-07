using System;
using System.Text.Json;
using MiniSocialMedia;

class Program
{
    private static readonly Repository<User> _users = new();
    private static User? _currentUser;
    private static readonly string _dataFile = "social-data.json";

    static void Main()
    {
        Console.Title = "MiniSocial - Console Edition";
        Console.WriteLine("=== MiniSocial ===\n");

        LoadData();

        while (true)
        {
            try
            {
                if (_currentUser == null)
                {
                    ShowLoginMenu();
                }
                else
                {
                    ShowMainMenu();
                }
            }
            catch (SocialException ex)
            {
                ConsoleColor original = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($" → {ex.InnerException.Message}");
                Console.ForegroundColor = original;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error!");
                Console.WriteLine(ex);
                LogError(ex);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }

    private static void ShowLoginMenu()
    {
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Login");
        Console.WriteLine("0. Exit");
        Console.Write("\nChoice: ");

        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                Register();
                break;
            case "2":
                Login();
                break;
            case "0":
                SaveData();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private static void Register()
    {
        Console.Write("Username: ");
        string? username = Console.ReadLine()?.Trim();

        Console.Write("Email: ");
        string? email = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
        {
            Console.WriteLine("Both fields required.");
            return;
        }

        if (_users.GetAll().Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Username already taken.");
            return;
        }

        var user = new User(username, email);
        _users.Add(user);
        Console.WriteLine($"Welcome, {user}!");
    }

    private static void Login()
    {
        Console.Write("Username: ");
        string? username = Console.ReadLine()?.Trim();

        var user = _users.GetAll()
            .FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        _currentUser = user;
        Console.WriteLine($"Logged in as {user.GetDisplayName()}");

        // Subscribe to notifications using delegate/event
        user.OnNewPost += p => ConsoleColorWrite(
            ConsoleColor.Cyan,
            $"\n[Notification] New post from {p.Author}: {p.Content[..Math.Min(40, p.Content.Length)]}...\n");
    }

    private static void ShowMainMenu()
    {
        if (_currentUser == null) return;

        Console.WriteLine($"Logged in: {_currentUser}");
        Console.WriteLine("1. Post message");
        Console.WriteLine("2. View my posts");
        Console.WriteLine("3. View timeline (feed)");
        Console.WriteLine("4. Follow user");
        Console.WriteLine("5. List users");
        Console.WriteLine("6. Logout");
        Console.WriteLine("0. Exit & Save");
        Console.Write("\nChoice: ");

        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                PostMessage();
                break;
            case "2":
                ShowPosts(_currentUser.GetPosts());
                break;
            case "3":
                ShowTimeline();
                break;
            case "4":
                FollowUser();
                break;
            case "5":
                ListUsers();
                break;
            case "6":
                _currentUser = null;
                Console.WriteLine("Logged out.");
                break;
            case "0":
                SaveData();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private static void PostMessage()
    {
        if (_currentUser == null) return;

        Console.WriteLine("Write your post (max 280 chars, empty to cancel):");
        string? content = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(content))
        {
            Console.WriteLine("Post cancelled.");
            return;
        }

        _currentUser.AddPost(content);
        Console.WriteLine("Posted successfully!");
    }

    private static void ShowTimeline()
    {
        if (_currentUser == null) return;

        var timeline = new List<Post>();

        // Own posts
        timeline.AddRange(_currentUser.GetPosts());

        // Followed users' posts
        foreach (var followedName in _currentUser.GetFollowingNames()) // We'll add helper
        {
            var followed = _users.GetAll().FirstOrDefault(u => u.Username.Equals(followedName, StringComparison.OrdinalIgnoreCase));
            if (followed != null)
                timeline.AddRange(followed.GetPosts());
        }

        timeline.Sort((a, b) => b.CreatedAt.CompareTo(a.CreatedAt)); // Newest first

        Console.WriteLine("=== Your Timeline ===\n");
        ShowPosts(timeline);
    }

    private static void ShowPosts(IEnumerable<Post> posts)
    {
        int count = 0;
        foreach (var post in posts.Take(20)) // limit display
        {
            Console.WriteLine(post);
            Console.WriteLine($"  {post.CreatedAt.FormatTimeAgo()}");
            Console.WriteLine(new string('-', 60));
            count++;
        }

        if (count == 0)
            Console.WriteLine("No posts yet.");
    }

    private static void FollowUser()
    {
        if (_currentUser == null) return;

        Console.Write("Username to follow: ");
        string? target = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(target))
        {
            Console.WriteLine("Cancelled.");
            return;
        }

        if (string.Equals(target, _currentUser.Username, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("You cannot follow yourself.");
            return;
        }

        if (!_users.GetAll().Any(u => u.Username.Equals(target, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("User not found.");
            return;
        }

        _currentUser.Follow(target);
        Console.WriteLine($"Now following @{target}");
    }

    private static void ListUsers()
    {
        Console.WriteLine("Registered users:");
        foreach (var u in _users.GetAll().OrderBy(u => u))
        {
            Console.WriteLine($"  @{u.Username,-20} {u.Email}");
        }
    }

    private static void SaveData()
    {
        try
        {
            var data = new
            {
                Users = _users.GetAll().Select(u => new
                {
                    u.Username,
                    u.Email,
                    Following = u.GetFollowingNames(), // Helper needed
                    Posts = u.GetPosts().Select(p => new { p.Content, CreatedAt = p.CreatedAt })
                })
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dataFile, json);
            Console.WriteLine("Data saved.");
        }
        catch (Exception ex)
        {
            LogError(ex);
            Console.WriteLine("Failed to save data.");
        }
    }

    private static void LoadData()
    {
        if (!File.Exists(_dataFile)) return;

        try
        {
            string json = File.ReadAllText(_dataFile);
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

            // Simplified - in real project use proper deserialization with classes
            Console.WriteLine("Data loaded (simulation - add proper logic).");
        }
        catch (Exception ex)
        {
            LogError(ex);
            Console.WriteLine("Failed to load data.");
        }
    }

    private static void LogError(Exception ex)
    {
        try
        {
            string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} ERROR: {ex.Message}\n{ex.StackTrace}\n\n";
            File.AppendAllText("social-error.log", log);
        }
        catch { /* silent fail for logger */ }
    }

    private static void ConsoleColorWrite(ConsoleColor color, string text)
    {
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = prev;
    }
}

// Helper extension for User (following names)
public static class UserExtensions
{
    // Normally you'd add private field, but for demo:
    public static IEnumerable<string> GetFollowingNames(this User user)
    {
        // Reflection or better design needed in real code - here we simulate
        // In full version: add private HashSet to User
        return Enumerable.Empty<string>(); // Placeholder - extend User class
    }
}