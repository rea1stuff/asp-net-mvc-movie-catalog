using MovieCatalog.Domain.Interfaces;

namespace MovieCatalog.Domain.Entities;

public class Movie : BaseEntity, IAggregateRoot
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public string ImageName { get; set; }
    public User User { get; set; }
}