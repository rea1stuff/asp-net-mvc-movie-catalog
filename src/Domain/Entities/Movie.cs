using MovieCatalog.Domain.Entities.ValueObjects;
using MovieCatalog.Domain.Interfaces;

namespace MovieCatalog.Domain.Entities;

public class Movie : BaseEntity, IAggregateRoot
{
    public string Title { get; }
    public string Description { get; }
    public ReleaseYear ReleaseYear { get; }
    public Director Director { get; }
    public string Path { get; }
    public User User { get; }
}