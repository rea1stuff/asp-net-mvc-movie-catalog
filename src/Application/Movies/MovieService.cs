using Ardalis.GuardClauses;
using AutoMapper;
using MovieCatalog.Application.Interfaces;
using MovieCatalog.Application.Movies.Dtos;
using MovieCatalog.Application.Movies.ViewModels;
using MovieCatalog.Domain.Interfaces.Repositories;
using MovieCatalog.Domain.Entities;
using MovieCatalog.Domain.Specs;

namespace MovieCatalog.Application.Movies;

public class MovieService : IMovieService
{
    private readonly IImageRepository _imageRepository;
    private readonly IMovieCatalogRepository<Movie> _movieRepository;
    private readonly IMovieCatalogRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public MovieService(
        IImageRepository imageRepository, 
        IMovieCatalogRepository<Movie> movieRepository, 
        IMovieCatalogRepository<User> userRepository, 
        IMapper mapper)
    {
        _imageRepository = imageRepository;
        _movieRepository = movieRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task CreateMovie(MovieDto model, string uId)
    {
        string fileName = Guid.NewGuid() + $"{Path.GetExtension(model.ImageFile.FileName)}";
        
        await _imageRepository.SaveAsync(model.ImageFile.OpenReadStream(), fileName);
        var user = await _userRepository.GetByIdAsync(uId);
        Guard.Against.Null(user);
        
        var movie = _mapper.Map<Movie>(model);
        movie.ImageName = fileName;
        movie.User = user;
        
        await _movieRepository.AddAsync(movie);
        await _movieRepository.SaveChangesAsync();
    }

    public async Task Edit(MovieDto model, string uId)
    {
        var movie = await _movieRepository.GetBySpecAsync(new MovieWithUserSpec(model.Id));
        Guard.Against.Null(movie);
        
        if (movie.User.Id != uId)
        {
            throw new Exception();
        }

        string fileName;
        if (model.ImageFile != null)
        {
            _imageRepository.Delete(movie.ImageName);
            fileName = Guid.NewGuid() + $"{Path.GetExtension(model.ImageFile.FileName)}";
            await _imageRepository.SaveAsync(model.ImageFile.OpenReadStream(), fileName);
        }
        else
        {
            fileName = movie.ImageName;
        }

        movie.Description = model.Description;
        movie.Director = model.Director;
        movie.Title = model.Title;
        movie.ImageName = fileName;
        movie.ReleaseYear = model.ReleaseYear;

        await _movieRepository.UpdateAsync(movie);
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

    public async Task<MoviesViewModel> GetMoviesByPage(int pageNumber, int itemsPerPage)
    {
        int skip = pageNumber * itemsPerPage;
        
        var movies = 
            await _movieRepository.ListAsync(new MoviesByPageSpec(itemsPerPage, skip));
        var moviesViewModel = new MoviesViewModel();

        foreach (var movie in movies)
        {
            var movieDto = _mapper.Map<MovieDto>(movie);
            movieDto.ImagePath = _imageRepository.GetRelativePath(movie.ImageName);
            
            moviesViewModel.Movies.Add(movieDto);
        }
        
        moviesViewModel.PageInfo.CurrentPageNumber = pageNumber;
        moviesViewModel.PageInfo.NextPageNumber = ++pageNumber;
        
        return moviesViewModel;
    }

    public async Task<MovieDto> GetMovieById(int movieId)
    {
        var movie = await _movieRepository.GetByIdAsync(movieId);
        
        var movieDto = _mapper.Map<Movie, MovieDto>(movie);
        movieDto.ImagePath = _imageRepository.GetRelativePath(movie.ImageName);
        
        return movieDto;
    }
}