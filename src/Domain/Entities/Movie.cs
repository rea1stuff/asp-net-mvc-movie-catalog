using MovieCatalog.Domain.Entities.ValueObjects;

namespace MovieCatalog.Domain.Entities;

public class Movie : BaseEntity
{
    public string Title { get; }
    public string Description { get; }
    public ReleaseYear ReleaseYear { get; }
    public Director Director { get; }
    public string Path { get; }
    public User User { get; }
}