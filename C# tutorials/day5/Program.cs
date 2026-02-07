using System;
using System.Collections.Generic;
using LibraryItems = LibrarySystem.Items;
using LibraryUsers = LibrarySystem.Users;

class Program
{
    public static void Main()
    {
        Console.WriteLine();
        var book = new LibraryItems.Book { Title = "C# Fundamentals", Author = "John Doe", ItemID = 101 };
        var magazine = new LibraryItems.Magazine { Title = "Tech Today", Author = "Jane Doe", ItemID = 201 };
        
        book.DisplayItemDetails();
        Console.WriteLine($"Late Fee for 3 days: {book.CalculateLateFee(3)}");
        Console.WriteLine();
        
        magazine.DisplayItemDetails();
        Console.WriteLine($"Late Fee for 3 days: {magazine.CalculateLateFee(3)}");
        Console.WriteLine();

        Console.WriteLine();
        ((IReservable)book).ReserveItem();
        ((INotifiable)book).SendNotification("Your reserved book is ready for pickup.");
        Console.WriteLine();

        Console.WriteLine();
        List<LibrarySystem.Items.LibraryItem> items = new List<LibrarySystem.Items.LibraryItem> { book, magazine };
        foreach (var item in items)
        {
            item.DisplayItemDetails();
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.WriteLine();
        IReservable reservableBook = book;
        INotifiable notifiableBook = book;
        reservableBook.ReserveItem();
        notifiableBook.SendNotification("Please return the book on time.");
        Console.WriteLine();

        Console.WriteLine();
        var aliasBook = new LibraryItems.Book();
        var aliasMagazine = new LibraryItems.Magazine();
        Console.WriteLine("Book and Magazine objects created using namespace alias.");
        Console.WriteLine();

        Console.WriteLine();
        LibraryAnalytics.TotalBorrowedItems = 5;
        LibraryAnalytics.DisplayAnalytics();
        Console.WriteLine();

        Console.WriteLine();
        var member = new LibraryUsers.Member { Name = "Alice", Role = UserRole.Member };
        var itemStatus = ItemStatus.Borrowed;
        Console.WriteLine($"User Role: {member.Role}");
        Console.WriteLine($"Item Status: {itemStatus}");
        Console.WriteLine();

        Console.WriteLine();
        member.SendRoleBasedNotification();
        var admin = new LibraryUsers.Member { Role = UserRole.Admin };
        admin.SendRoleBasedNotification();
        
        var ebook = new LibraryItems.eBook { Title = "Digital C#", Author = "Tech Author", ItemID = 301 };
        ebook.DownloadBook();
    }
}