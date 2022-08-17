using Ardalis.Specification;
using MovieCatalog.Domain.Entities;

namespace MovieCatalog.Domain.Specs;

public sealed class UserWithMoviesSpec : Specification<User>, ISingleResultSpecification
{
    public UserWithMoviesSpec(string uId)
    {
        Query.Where(u => u.Id == uId).Include(u => u.Movies);
    }
}