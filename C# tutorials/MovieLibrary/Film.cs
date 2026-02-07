public interface IFilm
{
    string Title { get; }
    string Director { get; }
    int Year { get; }
}

public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

public class Film : IFilm
{
    public string Title { get; private set; }
    public string Director { get; private set; }
    public int Year { get; private set; }

    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }
}

public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films = new List<IFilm>();

    public void AddFilm(IFilm film)
    {
        if (film != null)
        {
            _films.Add(film);
        }
    }

    public void RemoveFilm(string title)
    {
        var filmToRemove = _films
            .FirstOrDefault(f => f.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (filmToRemove != null)
        {
            _films.Remove(filmToRemove);
        }
    }

    public List<IFilm> GetFilms()
    {
        return new List<IFilm>(_films);
    }

    public List<IFilm> SearchFilms(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return new List<IFilm>();

        return _films
            .Where(f =>
                f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                f.Director.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}
