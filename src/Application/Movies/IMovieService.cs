using MovieCatalog.Application.Movies.Dtos;

namespace MovieCatalog.Application.Movies;

public interface IMovieService
{
    public Task CreateMovie(MovieDto model, string uId);

    public Task Edit(MovieDto model, int movieId, string uId);

    public Task Remove(int movieId, string uId);
    //public Task GetMoviesByPagination();
}