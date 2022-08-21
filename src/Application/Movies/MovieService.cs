using Ardalis.GuardClauses;
using MovieCatalog.Application.Interfaces;
using MovieCatalog.Application.Movies.Dtos;
using MovieCatalog.Domain.Interfaces.Repositories;
using MovieCatalog.Domain.Entities;
using MovieCatalog.Domain.Entities.ValueObjects;
using MovieCatalog.Domain.Specs;

namespace MovieCatalog.Application.Movies;

public class MovieService : IMovieService
{
    private readonly IImageRepository _imageRepository;
    private readonly IMovieCatalogRepository<Movie> _movieRepository;
    private readonly IMovieCatalogRepository<User> _userRepository;

    public MovieService(
        IImageRepository imageRepository, 
        IMovieCatalogRepository<Movie> movieRepository, 
        IMovieCatalogRepository<User> userRepository)
    {
        _imageRepository = imageRepository;
        _movieRepository = movieRepository;
        _userRepository = userRepository;
    }
    
    public async Task CreateMovie(MovieDto model, string uId)
    {
        string fileName = Guid.NewGuid() + $"{Path.GetExtension(model.Image.FileName)}";
        await _imageRepository.SaveAsync(model.Image, fileName);
        var user = await _userRepository.GetByIdAsync(uId);
        Guard.Against.Null(user);
        
        var movie = new Movie(
            model.Title,
            model.Description,
            new ReleaseYear(model.ReleaseYear),
            new Director(model.Director),
            fileName,
            user);
        
        await _movieRepository.AddAsync(movie);
        await _movieRepository.SaveChangesAsync();
    }

    public async Task Edit(MovieDto model, int movieId, string uId)
    {
        var movie = await _movieRepository.GetBySpecAsync(new MovieWithUserSpec(movieId));
        Guard.Against.Null(movie);
        
        if (movie.User.Id != uId)
        {
            throw new Exception();
        }

        string fileName;
        if (model.Image != null)
        {
            _imageRepository.Delete(movie.ImageName);
            fileName = Guid.NewGuid() + $"{Path.GetExtension(model.Image.FileName)}";
            await _imageRepository.SaveAsync(model.Image, fileName);
        }
        else
        {
            fileName = movie.ImageName;
        }

        var updatedMovie = new Movie(
            model.Title,
            model.Description,
            new ReleaseYear(model.ReleaseYear),
            new Director(model.Director),
            fileName,
            movie.User
        );

        await _movieRepository.UpdateAsync(updatedMovie);
        await _movieRepository.SaveChangesAsync();
    }

    public async Task Remove(int movieId, string uId)
    {
        var movie = await _movieRepository.GetBySpecAsync(new MovieWithUserSpec(movieId));
        Guard.Against.Null(movie);
        
        if (movie.User.Id != uId)
        {
            throw new Exception();
        }
        
        _imageRepository.Delete(movie.ImageName);
        await _movieRepository.DeleteAsync(movie);
    }
}