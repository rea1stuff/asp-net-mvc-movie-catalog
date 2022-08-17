using Ardalis.Specification.EntityFrameworkCore;
using MovieCatalog.Domain.Interfaces;
using MovieCatalog.Domain.Interfaces.Repositories;

namespace MovieCatalog.Infrastructure.MovieCatalog;

public class MovieCatalogRepository<T>
    : RepositoryBase<T>, IMovieCatalogRepository<T> where T : class, IAggregateRoot
{
    public MovieCatalogRepository(MovieCatalogContext dbContext)
        : base(dbContext)
    {
        
    }
}