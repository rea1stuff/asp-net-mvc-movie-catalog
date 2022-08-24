using FluentValidation;
using MovieCatalog.Application.Movies.Dtos;

namespace MovieCatalog.Application.Validation;

public class MovieValidation : AbstractValidator<MovieDto>
{
    public MovieValidation()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.ReleaseYear).NotEmpty().GreaterThan(1000);
        RuleFor(x => x.Director).NotEmpty();
    }
}