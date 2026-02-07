class Program
{
    static void Main()
    {
        IFilmLibrary library = new FilmLibrary();

        library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
        library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));

        var results = library.SearchFilms("Nolan");

        Console.WriteLine("Search Results:");
        foreach (var film in results)
        {
            Console.WriteLine($"{film.Title} ({film.Year}) - {film.Director}");
        }

        Console.WriteLine("Total films: " + library.GetTotalFilmCount());

        library.RemoveFilm("Inception");

        Console.WriteLine("Total films after removal: " + library.GetTotalFilmCount());
    }
}
