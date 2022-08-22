using MovieCatalog.Application.Movies.Dtos;

namespace MovieCatalog.Application.Movies.ViewModels;

public class MoviesViewModel
{
    public List<MovieDto> Movies { get; set; } = new();
    public PageInfoViewModel PageInfo { get; set; } = new();
}