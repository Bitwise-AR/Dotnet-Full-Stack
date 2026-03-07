using LibraryMVC.Models;
using MVCListRepo.Data;

namespace LibraryMVC.Repositories
{
    public class SQLLibraryRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public SQLLibraryRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public List<Book> ListAllBooks()
        {
            return context.Books.ToList();
        }

        public List<Book> ListByPrice(int price)
        {
            return context.Books
                .Where(b => b.Price > price)
                .ToList();
        }

        public Book ListBookByName(string name)
        {
            return context.Books
                .FirstOrDefault(b => b.Title == name);
        }
    }
}