using Ardalis.Specification;

namespace MovieCatalog.Domain.Interfaces.Repositories;

public interface IRepository<T> 
    : IRepositoryBase<T> where T : class, IAggregateRoot
{
    
}