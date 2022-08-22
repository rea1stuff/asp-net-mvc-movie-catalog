using Ardalis.Specification;
using MovieCatalog.Domain.Entities;

namespace MovieCatalog.Domain.Specs;

public sealed class MoviesByPageSpec : Specification<Movie>, ISingleResultSpecification
{
    public MoviesByPageSpec(int take, int skip)
    {
        Query.Include(x => x.User).Skip(skip).Take(take);
    }
}