using Ardalis.GuardClauses;
using MovieCatalog.Domain.Interfaces;

namespace MovieCatalog.Domain.Entities;

public class User : BaseEntity<string>, IAggregateRoot
{
    public User(string uId)
    {
        Id = uId;
    }
    public List<Movie> Movies { get; }

    public void AddMovie(Movie movie)
    {
        Guard.Against.Null(movie);
        
        Movies.Add(movie);
    }
}