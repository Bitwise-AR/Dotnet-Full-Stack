using LibraryMVC.Models;

namespace LibraryMVC.Repositories
{
    public class DictBookRepository : IBookRepository
    {
        private Dictionary<int, Book> books = new Dictionary<int, Book>();

        public DictBookRepository()
        {
            books.Add(1, new Book { BookId = 1, Title = "Java Basics", Author = "James", Price = 500 });
            books.Add(2, new Book { BookId = 2, Title = "C# Fundamentals", Author = "Anders", Price = 650 });
            books.Add(3, new Book { BookId = 3, Title = "Python Guide", Author = "Guido", Price = 400 });
        }

        public void AddBook(Book book)
        {
            books.Add(book.BookId, book);
        }

        public List<Book> ListAllBooks()
        {
            return books.Values.ToList();
        }

        public List<Book> ListByPrice(int price)
        {
            return books.Values
                        .Where(b => b.Price > price)
                        .ToList();
        }

        public Book ListBookByName(string name)
        {
            return books.Values
                        .FirstOrDefault(b => b.Title.ToLower() == name.ToLower());
        }
    }
}