using MovieCatalog.Application.Interfaces;
using MovieCatalog.Application.Users.Dtos;
using MovieCatalog.Domain.Entities;
using MovieCatalog.Domain.Interfaces.Repositories;

namespace MovieCatalog.Application.Users;

public class UserService : IUserService
{
    private readonly IUserIdentityService _userIdentityService;
    private readonly IMovieCatalogRepository<User> _movieCatalogRepository;

    public UserService(
        IUserIdentityService userIdentityService, 
        IMovieCatalogRepository<User> movieCatalogRepository)
    {
        _userIdentityService = userIdentityService;
        _movieCatalogRepository = movieCatalogRepository;
    }

    public async Task Register(RegistrationDto registrationDto)
    {
        string uId = Guid.NewGuid().ToString();
        
        await _userIdentityService.Register(registrationDto, uId);
        await _movieCatalogRepository.AddAsync(new User(uId));
    }

    public async Task Login(LoginDto loginDto)
    {
        await _userIdentityService.Login(loginDto);
    }

    public async Task Logout()
    {
        await _userIdentityService.Logout();
    }
}