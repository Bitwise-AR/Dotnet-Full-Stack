using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    // Custom Exception
    public class SocialException : Exception
    {
        public SocialException(string message) : base(message) { }
        public SocialException(string message, Exception inner) : base(message, inner) { }
    }

    // Interface example
    public interface IPostable
    {
        void AddPost(string content);
        IReadOnlyList<Post> GetPosts();
    }


    // Post class with object initializer support
    public class Post
    {
        public User Author { get; init; }
        public string Content { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

        public Post(User author, string content)
        {
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Content = content;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);
            var hashtags = Regex.Matches(Content, @"\B#\w*[A-Za-z]+\w*");
            if (hashtags.Count > 0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }


    // Entity base (partial class demo - normally split files)
    public partial class User : IPostable, IComparable<User>
    {
        public string Username { get; init; }
        public string Email { get; init; }
        private readonly List<Post> _posts = new();
        private readonly HashSet<string> _following = new(StringComparer.OrdinalIgnoreCase);

        public User(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new SocialException("Invalid email format");

            Username = username.Trim();
            Email = email.Trim().ToLowerInvariant();
        }

        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");

            _following.Add(username);
        }

        public bool IsFollowing(string username) => _following.Contains(username);

        // Event / Delegate
        public event Action<Post>? OnNewPost;

        // IPostable implementation
        public void AddPost(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content cannot be empty", nameof(content));

            if (content.Length > 280)
                throw new SocialException("Post too long (max 280 characters)");

            var post = new Post(this, content.Trim());
            _posts.Add(post);
            OnNewPost?.Invoke(post); // Event / Delegate
        }

        public IReadOnlyList<Post> GetPosts() => _posts.AsReadOnly();

        public int CompareTo(User? other)
        {
            if (other is null) return 1;
            return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => $"@{Username}";


    }






    public partial class User
    {
        // Extension method usage example (can be in separate file)
        public string GetDisplayName() => $"User: {Username} <{Email}>";
    }


    // Generic Repository (with constraints)
    public class Repository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);
        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();
        public T? Find(Predicate<T> match) => _items.Find(match);
    }


    // Static utility class
    public static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime dt)
        {
            var diff = DateTime.UtcNow - dt;
            if (diff.TotalMinutes < 1) return "just now";
            if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes} min ago";
            if (diff.TotalHours < 24) return $"{(int)diff.TotalHours} h ago";
            return dt.ToString("MMM dd");
        }
    }
}