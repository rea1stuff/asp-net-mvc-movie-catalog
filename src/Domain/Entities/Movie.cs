using MovieCatalog.Domain.Entities.ValueObjects;
using MovieCatalog.Domain.Interfaces;

namespace MovieCatalog.Domain.Entities;

public class Movie : BaseEntity, IAggregateRoot
{
    private Movie()
    {
        
    }
    public Movie(
        string title, 
        string description, 
        ReleaseYear releaseYear, 
        Director director, 
        string imageName, 
        User user)
    {
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        Director = director;
        ImageName = imageName;
        User = user;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public ReleaseYear ReleaseYear { get; private set; }
    public Director Director { get; private set; }
    public string ImageName { get; private set; }
    public User User { get; private set; }
}