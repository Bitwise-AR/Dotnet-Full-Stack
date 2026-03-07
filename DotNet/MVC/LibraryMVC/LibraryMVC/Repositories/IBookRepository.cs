using LibraryMVC.Models;

namespace LibraryMVC.Repositories
{
    public interface IBookRepository
    {
        List<Book> ListAllBooks();

        List<Book> ListByPrice(int price);

        Book ListBookByName(string name);
        void AddBook(Book book);
    }
}
