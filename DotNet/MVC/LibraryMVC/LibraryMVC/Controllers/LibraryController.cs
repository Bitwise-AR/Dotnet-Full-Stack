using LibraryMVC.Models;
using LibraryMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBookRepository repo;

        public LibraryController(IBookRepository repository)
        {
            repo = repository;
        }

        public IActionResult AddBook(int id, string title, string author, float price)
        {
            Book b = new Book
            {
                BookId = id,
                Title = title,
                Author = author,
                Price = price
            };

            if (!TryValidateModel(b))
            {
                return Content("Invalid book details. Title max 15 chars and price must be greater than 0.");
            }

            repo.AddBook(b);

            return Content("Book Added Successfully");
        }

        public IActionResult ListAllBooks()
        {
            var books = repo.ListAllBooks();

            if (books == null || books.Count == 0)
            {
                return Content("No books available in the library.");
            }

            string result = "";

            foreach (var b in books)
            {
                result += $"{b.BookId} {b.Title} {b.Author} {b.Price}\n";
            }

            return Content(result);
        }

        public IActionResult ListByPrice(int price)
        {
            var books = repo.ListByPrice(price);

            if (books == null || books.Count == 0)
            {
                return Content($"No books found with price greater than {price}");
            }

            string result = "";

            foreach (var b in books)
            {
                result += $"{b.Title} - {b.Price}\n";
            }

            return Content(result);
        }

        public IActionResult ListBookByName(string name)
        {
            var b = repo.ListBookByName(name);

            if (b == null)
                return Content("Book not found");

            return Content($"{b.BookId} {b.Title} {b.Author} {b.Price}");
        }
    }
}