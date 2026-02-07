using System;
using System.Collections.Generic;
using LibraryItems = LibrarySystem.Items;
using LibraryUsers = LibrarySystem.Users;

// TASK 7: Enumerations
public enum UserRole { Admin, Librarian, Member }
public enum ItemStatus { Available, Borrowed, Reserved, Lost }

// TASK 2: Interfaces
public interface IReservable
{
    void ReserveItem();
}

public interface INotifiable
{
    void SendNotification(string message);
}

// TASK 5: Namespaces & Nested Namespaces
namespace LibrarySystem
{
    namespace Items
    {
        // TASK 1: Abstract Class
        public abstract class LibraryItem
        {
            public string? Title { get; set; }
            public string? Author { get; set; }
            public int ItemID { get; set; }

            public abstract void DisplayItemDetails();
            public abstract double CalculateLateFee(int numberOfDays);
        }

        // TASK 4: Explicit Interface Implementation
        public class Book : LibraryItem, IReservable, INotifiable
        {
            public override void DisplayItemDetails()
            {
                Console.WriteLine($"Item Type: Book\nTitle: {Title}\nAuthor: {Author}\nItem ID: {ItemID}");
            }

            public override double CalculateLateFee(int numberOfDays)
            {
                return numberOfDays * 1.0;
            }

            void IReservable.ReserveItem()
            {
                Console.WriteLine("Book reserved successfully.");
            }

            void INotifiable.SendNotification(string message)
            {
                Console.WriteLine($"Notification: {message}");
            }
        }

        public class Magazine : LibraryItem
        {
            public override void DisplayItemDetails()
            {
                Console.WriteLine($"Item Type: Magazine\nTitle: {Title}\nAuthor: {Author}\nItem ID: {ItemID}");
            }

            public override double CalculateLateFee(int numberOfDays)
            {
                return numberOfDays * 0.5;
            }
        }

        // BONUS: eBook class
        public class eBook : LibraryItem
        {
            public override void DisplayItemDetails()
            {
                Console.WriteLine($"Item Type: eBook\nTitle: {Title}\nAuthor: {Author}\nItem ID: {ItemID}");
            }

            public override double CalculateLateFee(int numberOfDays)
            {
                return numberOfDays * 0.25;
            }

            public void DownloadBook()
            {
                Console.WriteLine("eBook downloaded successfully.");
            }
        }
    }

    namespace Users
    {
        public class Member
        {
            public string? Name { get; set; }
            public UserRole Role { get; set; }

            public void SendRoleBasedNotification()
            {
                if (Role == UserRole.Admin)
                    Console.WriteLine("Admin Alert: System maintenance scheduled.");
                else
                    Console.WriteLine("Member Notification: Your borrowed item is due tomorrow.");
            }
        }
    }
}

// TASK 6: Partial Classes
public partial class LibraryAnalytics
{
    public static int TotalBorrowedItems { get; set; } = 0;
}

public partial class LibraryAnalytics
{
    public static void DisplayAnalytics()
    {
        Console.WriteLine($"Total Items Borrowed: {TotalBorrowedItems}");
    }
}
