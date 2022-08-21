using Ardalis.Specification.EntityFrameworkCore;
using MovieCatalog.Domain.Interfaces;
using MovieCatalog.Domain.Interfaces.Repositories;
using MovieCatalog.Infrastructure.MovieCatalog;

namespace MovieCatalog.Infrastructure.Repository;

public class MovieCatalogRepository<T>
    : RepositoryBase<T>, IMovieCatalogRepository<T> where T : class, IAggregateRoot
{
    public MovieCatalogRepository(MovieCatalogContext dbContext)
        : base(dbContext)
    {
        
    }
}