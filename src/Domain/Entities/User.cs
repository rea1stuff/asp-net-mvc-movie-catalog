using MovieCatalog.Domain.Interfaces;

namespace MovieCatalog.Domain.Entities;

public class User : BaseEntity<string>, IAggregateRoot
{
    private User()
    {
        
    }
    public User(string uId)
    {
        Id = uId;
    }
    public List<Movie> Movies { get; private set; }
}