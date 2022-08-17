namespace MovieCatalog.Domain.Interfaces.Repositories;

public interface IMovieCatalogRepository<T> 
    : IRepository<T> where T : class, IAggregateRoot
{
    
}