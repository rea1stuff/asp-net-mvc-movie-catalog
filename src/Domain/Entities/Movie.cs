namespace MovieCatalog.Domain.Entities;

public class Movie
{
    public string Title { get; }
    public string Description { get; }
    public ReleaseYear ReleaseYear { get; }
    public Director Director { get; }
    public User User { get; }
    public string Path { get; }
}