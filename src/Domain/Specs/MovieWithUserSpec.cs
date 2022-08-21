using Ardalis.Specification;
using MovieCatalog.Domain.Entities;

namespace MovieCatalog.Domain.Specs;

public sealed class MovieWithUserSpec : Specification<Movie>, ISingleResultSpecification
{
    public MovieWithUserSpec(int movieId)
    {
        Query.Where(x => x.Id == movieId).Include(x => x.User);
    }
}