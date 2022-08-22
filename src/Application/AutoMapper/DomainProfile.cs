using AutoMapper;
using MovieCatalog.Application.Movies.Dtos;
using MovieCatalog.Domain.Entities;

namespace MovieCatalog.Application.AutoMapper;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<Movie, MovieDto>();

        CreateMap<MovieDto, Movie>();
    }
}