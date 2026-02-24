using System;

namespace BookStoreApplication
{
    public class BookUtility
    {
        private Book _book;

        public BookUtility(Book book)
        {
            _book = book;
        }

        public void GetBookDetails()
        {
            Console.WriteLine($"Details: {_book.Id} {_book.Title} {_book.Price} {_book.Stock}");
        }

        public void UpdateBookPrice(int newPrice)
        {
            if (newPrice > 0)
            {
                _book.Price = newPrice;
                Console.WriteLine($"Updated Price: {newPrice}");
            }
        }

        public void UpdateBookStock(int newStock)
        {
            if (newStock >= 0)
            {
                _book.Stock = newStock;
                Console.WriteLine($"Updated Stock: {newStock}");
            }
        }
    }
}
