using MovieCatalog.Domain.Entities.ValueObjects;
using MovieCatalog.Domain.Interfaces;

namespace MovieCatalog.Domain.Entities;

public class Movie : BaseEntity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public ReleaseYear ReleaseYear { get; private set; }
    public Director Director { get; private set; }
    public string Path { get; private set; }
    public User User { get; private set; }
}